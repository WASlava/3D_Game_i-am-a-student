using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RayShooter : MonoBehaviour
{
    [SerializeField] private PlayerCharacter player;

    //private Camera _camera;

    //[SerializeField] private PlayerUI playerUI;

    [SerializeField] GUIStyle Style = new GUIStyle();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_camera = GetComponent<Camera>();

        //player = FindAnyObjectByType<PlayerCharacter>();
        //playerUI = FindAnyObjectByType<PlayerUI>();

        Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;            
      
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && player != null)
        {
            if (player.Shoot()) 
            {
                ShootRay();
            }
            else
            {
                Debug.Log("No ammo left!");
            }
        }

  
    }

    private void ShootRay()
    {
        if (CameraSwitcher.activeCamera == null) return;

        Camera cam = CameraSwitcher.activeCamera;

        Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
        Ray ray = cam.ScreenPointToRay(point);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1.0f); // Для перевірки

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            ReactiveEnemy target = hitObject.GetComponent<ReactiveEnemy>();

            if (target != null)
            {
                Debug.Log("Hit the enemy!");
                target.TakeDamage(20);
            }
            else
            {
                Debug.Log($"Hit: {hit.point}");
                StartCoroutine(SphereIndicator(hit.point, 2.0F));
            }
        }
    }

    private void OnGUI()
    {
        if (CameraSwitcher.activeCamera == null) return;

        Camera cam = CameraSwitcher.activeCamera;

        int size = 20;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+", Style);

    }

    private IEnumerator SphereIndicator(Vector3 position, float radius)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        yield return new WaitForSeconds(1.0F);
        Destroy(sphere);

    }

}

