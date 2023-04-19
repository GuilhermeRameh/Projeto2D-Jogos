using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    void Awake() { instance = this; }

    public List<GameObject> prefabs;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    public void StartSpawning()
    {   
        // Calls the spawn coroutine
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        // Call spawn method
        SpawnEnemy();
        // Wait spawn interval
        yield return new WaitForSeconds(spawnInterval);
        // Recall the same coroutine
        StartCoroutine(SpawnDelay());
    }

    void SpawnEnemy()
    {
        int randomPrefabID = Random.Range(0, prefabs.Count);
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoint);
    }
}
