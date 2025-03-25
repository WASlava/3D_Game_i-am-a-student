using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject ammoPrefab;
    public GameObject medPrefab;
    public float spawnInterval = 100f; // Час між спавнами
    public int maxItems = 3;

    public Vector3 spawnAreaMin = new Vector3(10, 1, 105);
    public Vector3 spawnAreaMax = new Vector3(90, 1, 190);
    private List<GameObject> spawnedItems = new List<GameObject>();

    void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 2f, spawnInterval);
    }

    void SpawnItem()
    {
        spawnedItems.RemoveAll(item => item == null);

        if (spawnedItems.Count >= maxItems)
        {
            return;
        }   

        Vector3 randomPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            spawnAreaMin.y,
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        GameObject itemToSpawn = Random.value > 0.5f ? ammoPrefab : medPrefab;
        GameObject newItem = Instantiate(itemToSpawn, randomPosition, Quaternion.identity);
        spawnedItems.Add(newItem);

        Debug.Log($"Spawned {newItem.name} at {randomPosition}");
    }
}
