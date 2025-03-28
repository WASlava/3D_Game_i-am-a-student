using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ReactiveEnemy))]


public class WaneringAi : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float obstacleRange = 20.0f;

    [SerializeField] private GameObject FireballPrefab;
    private GameObject _fireball;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReactiveEnemy obj = GetComponent<ReactiveEnemy>();
        if (obj == null || !obj.IsAlive())
        {
            return;
        }



        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            PlayerCharacter player = hitObject.GetComponent<PlayerCharacter>();
            if (player==null)
            {
                if (hit.distance < obstacleRange)
                {
                    float angle = UnityEngine.Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
            else
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(FireballPrefab, transform.position + transform.forward * 8f, transform.rotation);
                }
                transform.Translate(0, 0, speed * Time.deltaTime);
            }


        }
    }
}
