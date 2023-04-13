using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    public static AllySpawner instance;
    void Awake() { instance = this; }

    public List<GameObject> prefabs;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    public void StartSpawning()
    {   
        // Calls the spawn coroutine
        // StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        // Call spawn method
        SpawnAlly();
        // Wait spawn interval
        yield return new WaitForSeconds(spawnInterval);
        // Recall the same coroutine
        StartCoroutine(SpawnDelay());
    }

    void SpawnAlly()
    {
        int randomPrefabID = Random.Range(0, prefabs.Count);
        GameObject spawnedAlly = Instantiate(prefabs[randomPrefabID], spawnPoint);
    }
}
