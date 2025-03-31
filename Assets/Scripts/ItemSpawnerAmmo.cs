using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemSpawnerAmmo : MonoBehaviour
{
    public GameObject ammoPrefab;
    public float spawnAmmoInterval = 30f; 
    public int maxAmmoItems = 3;

    public Vector3 spawnAmmoAreaMin = new Vector3(10, 1, 105);
    public Vector3 spawnAmmoAreaMax = new Vector3(90, 1, 190);
    private List<GameObject> spawnedAmmoItems = new List<GameObject>();

    void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 2f, spawnAmmoInterval);
    }

    void SpawnItem()
    {
        spawnedAmmoItems.RemoveAll(item => item == null);

        if (spawnedAmmoItems.Count >= maxAmmoItems)
        {
            return;
        }   

        Vector3 randomPosition = new Vector3(
            Random.Range(spawnAmmoAreaMin.x, spawnAmmoAreaMax.x),
            spawnAmmoAreaMin.y,
            Random.Range(spawnAmmoAreaMin.z, spawnAmmoAreaMax.z)
        );

        GameObject newItem = Instantiate(ammoPrefab, randomPosition, Quaternion.identity);
        spawnedAmmoItems.Add(newItem);

        Debug.Log($"Spawned {newItem.name} at {randomPosition}");
    }
}
