using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemSpawnerMed : MonoBehaviour
{
    public GameObject medPrefab;
    public float spawnMedInterval = 30f;
    public int maxMedItems = 3;

    public Vector3 spawnMedAreaMin = new Vector3(10, 2, 105);
    public Vector3 spawnMedAreaMax = new Vector3(90, 2, 190);
    private List<GameObject> spawnedMedItems = new List<GameObject>();

    void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 2f, spawnMedInterval);
    }

    void SpawnItem()
    {
        spawnedMedItems.RemoveAll(item => item == null);

        if (spawnedMedItems.Count >= maxMedItems)
        {
            return;
        }   

        Vector3 randomPosition = new Vector3(
            Random.Range(spawnMedAreaMin.x, spawnMedAreaMax.x),
            spawnMedAreaMin.y,
            Random.Range(spawnMedAreaMin.z, spawnMedAreaMax.z)
        );

        GameObject newItem = Instantiate(medPrefab, randomPosition, Quaternion.identity);
        spawnedMedItems.Add(newItem);

        Debug.Log($"Spawned {newItem.name} at {randomPosition}");
    }
}
