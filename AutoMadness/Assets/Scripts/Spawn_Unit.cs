using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn_Unit : MonoBehaviour
{ 
    public GameObject origin;
    public GameObject ranged;
    public GameObject melee;
    public GameObject shield;
    public GameObject turret;
    public GameObject missil;
    public GameObject error_msg;
    public int ranged_price;
    public int melee_price;
    public int shield_price;
    private Menu_Controller menuController;
    private Upgrades upgrades;
    private Currency coins;
    public int cooldown;
    public int has_turret;
    public int has_missil;
    private Vector3 shield_spawn;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        coins = GameObject.Find("Money").GetComponent<Currency>();
        //turret.SetActive(false);
        // upgrades = GameObject.Find("SpawnUnit").GetComponent<Upgrades>();
        // ranged = upgrades.ranged;
        // melee = upgrades.melee;
        // shield = upgrades.shield;
        ranged_price = 2;
        melee_price = 1;
        shield_price = 4;
        cooldown = 0;
        error_msg.SetActive(false);
        has_turret = 0;
        has_missil = 0;
    }

    // Update is called once per fSrame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            shield_spawn = new Vector3(origin.transform.position.x, origin.transform.position.y + .8f, origin.transform.position.z);
            Instantiate(shield, shield_spawn, Quaternion.identity);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)){
            Instantiate(missil, origin.transform.position, Quaternion.identity);
            has_missil = 1;
        }

        if(has_missil == 1){
            cooldown += 1;
            if (cooldown >= 100){
                cooldown = 0;
                has_missil = 0;
            }
        }

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

    public void spawn_shield()
    {
        if (coins.wallet >= shield_price){
            error_msg.SetActive(false);
            shield_spawn = new Vector3(origin.transform.position.x, origin.transform.position.y + 2, origin.transform.position.z);
            Instantiate(shield, shield_spawn, Quaternion.identity);
            coins.wallet -= shield_price;
        } else {
            error_msg.SetActive(true);
        }
    }

    public void spawn_turret()
    {
        if (coins.wallet >= 5 && has_turret == 0){
            error_msg.SetActive(false);
            turret.SetActive(true);
            coins.wallet -= 10;
            has_turret = 1;
        } else {
            //Might break
            error_msg.transform.GetComponent<TextMeshProUGUI>().text = "You already have a turret!";
            error_msg.SetActive(true);
        }
    }

    public void spawn_missil()
    {
        if (coins.wallet >= 10 && has_missil == 0){
            error_msg.SetActive(false);
            Instantiate(missil, origin.transform.position, Quaternion.identity);
            coins.wallet -= 5;
            has_missil = 1;
        } else {
            error_msg.SetActive(true);
            if (has_missil == 1){
                //Might break
                error_msg.transform.GetComponent<TextMeshProUGUI>().text = "Missile in cooldown";
            }
        }
    }
}
