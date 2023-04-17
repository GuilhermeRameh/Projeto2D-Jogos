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
    private int cooldown;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("Canvas").GetComponent<Menu_Controller>();
        coins = GameObject.Find("Money").GetComponent<Currency>();
        upgrades = GameObject.Find("Infantry").GetComponent<Upgrades>();
        ranged = upgrades.ranged;
        melee = upgrades.melee;
        ranged_price = 2;
        melee_price = 1;
        cooldown = 0;
        error_msg.SetActive(false);
    }

    // Update is called once per fSrame
    void Update()
    {
        if(menuController.end == false){
            spawn();
        }

        if (cooldown > 0){
            cooldown -= 1;
        } else {
            error_msg.SetActive(false);
        }
    }

    void spawn()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            if (coins.wallet >= melee_price){
                Instantiate(melee, origin.transform.position, Quaternion.identity);
                coins.wallet -= melee_price;
            } else {
                error_msg.SetActive(true);
                cooldown = 15;
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha2)){
            if (coins.wallet >= ranged_price){
                Instantiate(ranged, origin.transform.position, Quaternion.identity);
                coins.wallet -= ranged_price;
            } else {
                error_msg.SetActive(true);
                cooldown = 15;
            }
        }
    }
}
