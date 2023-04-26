using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn_Unit : MonoBehaviour
{ 
    public GameObject origin;
    public GameObject ranged;
    public GameObject melee;
    public GameObject error_msg;
    public int ranged_price;
    public int melee_price;
    private Menu_Controller menuController;
    private Upgrades upgrades;
    private Currency coins;
    public int cooldown;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        coins = GameObject.Find("Money").GetComponent<Currency>();
        // upgrades = GameObject.Find("SpawnUnit").GetComponent<Upgrades>();
        // ranged = upgrades.ranged;
        // melee = upgrades.melee;
        ranged_price = 2;
        melee_price = 1;
        cooldown = 0;
        error_msg.SetActive(false);
    }

    // Update is called once per fSrame
    void Update()
    {

    }

    public void spawn_melee()
    {

        if (coins.wallet >= melee_price){
            error_msg.SetActive(false);
            Instantiate(melee, origin.transform.position, Quaternion.identity);
            coins.wallet -= melee_price;
        } else {
            error_msg.SetActive(true);
        }

    }

    public void spawn_ranged()
    {
        if (coins.wallet >= ranged_price){
            error_msg.SetActive(false);
            Instantiate(ranged, origin.transform.position, Quaternion.identity);
            coins.wallet -= ranged_price;
        } else {
            error_msg.SetActive(true);
        }
    }
}
