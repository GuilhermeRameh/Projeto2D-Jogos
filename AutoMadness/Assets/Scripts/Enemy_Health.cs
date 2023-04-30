using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public float health;
    private float maxHealth;
    private Currency coins;
    private Level_Manager level;

    // Start is called before the first frame update
    void Start()
    {
        coins = GameObject.Find("Money").GetComponent<Currency>();
        level = GameObject.Find("Level").GetComponent<Level_Manager>();
        health = level.enemy_health;
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            coins.wallet += 1;
            Destroy(gameObject);
        }
    }
}
