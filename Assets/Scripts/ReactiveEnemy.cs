using System.Collections;
using UnityEngine;

public class ReactiveEnemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private bool isAlive = true;
    private bool isWounded = false;
    private float normalSpeed = 5f;
    private float woundedSpeed = 1f;
    private float speed;

    public GameObject firePrefab;
    private GameObject fireInstance;
    private bool isDestroyed = false;

    private EnemyHealthUI healthUI; 

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        healthUI?.UpdateHealthBar(currentHealth, maxHealth);
        Debug.Log("Enemy healed! Current Health: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive) return;

        currentHealth -= damage;
        healthUI?.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= maxHealth / 2 && !isWounded)
        {
            isWounded = true;
            speed = woundedSpeed;
        }

        if (currentHealth <= 0)
        {
            isAlive = false;
            StartCoroutine(Die());
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        speed = normalSpeed;

        healthUI = GetComponent<EnemyHealthUI>(); 
        healthUI?.Initialize(maxHealth);
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

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
            fireInstance.transform.SetParent(transform);
        }
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    private IEnumerator Die()
    {
        healthUI?.DestroyHealthBar();

        SpawnFire();
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
