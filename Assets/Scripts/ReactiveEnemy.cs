using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactiveEnemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public GameObject firePrefab;
    private GameObject fireInstance;
    private bool isDestroyed = false;
    private int currentHealth;
    private bool isWounded = false;
    private float normalSpeed = 5f;
    private float woundedSpeed = 1f;
    private float speed;
    private bool isAlive = true;


    [SerializeField] private GameObject healthBarPrefab; // Префаб індикатора
    private Slider healthBar;
    private Transform canvasTransform;

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Enemy healed! Current Health: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive) return;

        currentHealth -= damage;
        if (currentHealth <= maxHealth / 2 && !isWounded)
        {
            isWounded = true;
            speed = woundedSpeed;
        }

        if (healthBar)
        {
            healthBar.value = (float)currentHealth / maxHealth * 100;
        }

        if (currentHealth <= 0)
        {
            isAlive = false;
            StartCoroutine(Die());
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        speed = normalSpeed;

        //GameObject healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
        GameObject healthBarInstance = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
        healthBar = healthBarInstance.GetComponentInChildren<Slider>();
        canvasTransform = healthBarInstance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        if (healthBar)
        {
            canvasTransform.position = transform.position + Vector3.up * 2f;
            canvasTransform.LookAt(Camera.main.transform);
        }
        if (isDestroyed && fireInstance == null)
        {
            SpawnFire();
        }
    }

    void SpawnFire()
    {
        if (firePrefab != null)
        {
            fireInstance = Instantiate(firePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            fireInstance.transform.SetParent(transform); // Вогонь рухається разом із танком
        }
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    private IEnumerator Die()
    {

        if (healthBar)
        {
            Destroy(healthBar.gameObject); // Видаляємо індикатор при смерті
        }

        //transform.Rotate(90.0f, 0, 0);
        //transform.Translate(0, 3.0f, 1.5f);
        SpawnFire();
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
