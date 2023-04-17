using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public float health;
    private float maxHealth;
    private Currency coins;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        coins = GameObject.Find("Money").GetComponent<Currency>();
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
