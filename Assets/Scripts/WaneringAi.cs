using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReactiveEnemy))]
public class WanderingAi : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float obstacleRange = 20.0f;
    [SerializeField] private GameObject FireballPrefab;
    private GameObject _fireball;

    private ReactiveEnemy _enemy;

    void Start()
    {
        _enemy = GetComponent<ReactiveEnemy>();
    }

    void Update()
    {
        if (_enemy == null || !_enemy.IsAlive())
        {
            return;
        }

        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Player"))
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(FireballPrefab, transform.position + transform.forward * 1.5f, transform.rotation);
                    Physics.IgnoreCollision(_fireball.GetComponent<Collider>(), GetComponent<Collider>()); 
                }
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
            else if (hitObject.CompareTag("MedBox") && hit.distance < 1.5f)
            {
                PickupItem pickup = hitObject.GetComponent<PickupItem>();
                if (pickup != null)
                {
                    _enemy.Heal(10);
                    Destroy(hitObject);
                }
            }
            else if (!hitObject.CompareTag("MedBox") && hit.distance < obstacleRange) 
            {
                float angle = UnityEngine.Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
