using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private static int maxEnemies = 5;
    [SerializeField] private int maxRespawns = 10;
    [SerializeField] private float respawnDelay = 5.0f;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject wallToDestroy;

    private GameObject[] _enemies = new GameObject[maxEnemies];
    private int respawnCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            if (_enemies[i] == null && respawnCount < maxRespawns)
            {
                StartCoroutine(RespawnEnemy(i));
            }
        }

        if ( respawnCount==maxRespawns)
        {
            bool allEnemiesDestroyed = true;
            foreach (var enemy in _enemies)
            {
                if (enemy != null)
                {
                    allEnemiesDestroyed = false;
                    break;
                }
            }
            if (allEnemiesDestroyed && wallToDestroy != null)
            {
                Destroy(wallToDestroy);
                wallToDestroy = null; 
            }
        }
    }

    private IEnumerator RespawnEnemy(int index)
    {
        //yield return new WaitForSeconds(respawnDelay); 

        if (respawnCount < maxRespawns)
        {
            _enemies[index] = Instantiate(enemyPrefab);
            _enemies[index].transform.position = new Vector3(Random.Range(10, 90), 1.25F, Random.Range(105, 190));
            _enemies[index].transform.Rotate(0, Random.Range(0, 360), 0);
            respawnCount++;


            Canvas healthCanvas = _enemies[index].GetComponentInChildren<Canvas>();
            if (healthCanvas != null)
            {
                healthCanvas.worldCamera = Camera.main;
            }
            yield return new WaitForSeconds(respawnDelay);
        }
    }
}
