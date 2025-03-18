using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RayShooter : MonoBehaviour
{
    [SerializeField] GUIStyle Style = new GUIStyle();
    private Camera _camera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = GetComponent<Camera>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;            
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2.0F, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveEnemy target = hitObject.GetComponent<ReactiveEnemy>();
                if (target != null)
                {
                    Debug.Log("Hit the enemy");
                    target.TakeDamage(20);
                }
                else
                {
                    Debug.Log(String.Format($"Hit: X = {hit.point.x}, Y = {hit.point.y}, Z = {hit.point.z} "));
                    StartCoroutine(SphereIndicator(hit.point, 2.0F));

                }
           }

        }
    }


    private void OnGUI()
    {
        int size = 20;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
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

