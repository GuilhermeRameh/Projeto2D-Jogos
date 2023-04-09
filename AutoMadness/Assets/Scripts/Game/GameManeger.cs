using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public static GameManeger instance;
    void Awake() { instance = this; }

    void Start()
    {
        // Starts spawning enemies after short delay
        StartCoroutine(waveStartDelay());
    }

    IEnumerator waveStartDelay()
    {
        yield return new WaitForSeconds(2f);
        EnemySpawner.instance.StartSpawning();
        AllySpawner.instance.StartSpawning();
    }
}
