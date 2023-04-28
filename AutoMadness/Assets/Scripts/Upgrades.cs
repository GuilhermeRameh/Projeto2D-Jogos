using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public GameObject melee;
    public GameObject ranged;
    public GameObject shield;
    public GameObject error_msg;
    public GameObject bullet;
    public Spawn_Unit spawn;

    private Currency coins;
    public int cooldown;
    public TextMeshProUGUI melee_price;
    public TextMeshProUGUI ranged_price;
    public TextMeshProUGUI shield_price;
    // Start is called before the first frame update
    void Start()
    {
        melee = (GameObject)Resources.Load("Prefabs/MeleeUnit", typeof(GameObject));
        ranged = (GameObject)Resources.Load("Prefabs/RangedUnit", typeof(GameObject));
        shield = (GameObject)Resources.Load("Prefabs/ShieldUnit", typeof(GameObject));

        spawn = GameObject.Find("SpawnAllies").GetComponent<Spawn_Unit>();
        coins = GameObject.Find("Money").GetComponent<Currency>();
        cooldown = 0;
        error_msg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void upgrade_melee(){
        if (coins.wallet >= 5){
            error_msg.SetActive(false);
            melee = (GameObject)Resources.Load("Prefabs/MeleeUpgrade", typeof(GameObject));
            melee.GetComponent<Swing>().dmg += 1;
            melee.GetComponent<Unit_Health>().health += 1;
            spawn.melee_price += 1;
            melee_price.text = spawn.melee_price.ToString();
            spawn.melee = melee;
            coins.wallet -= 5;
        } else {
            error_msg.SetActive(true);
        }
    }

    public void upgrade_ranged(){
         if (coins.wallet >= 5){
            error_msg.SetActive(false);
            ranged = (GameObject)Resources.Load("Prefabs/RangedUpgrade", typeof(GameObject));
            bullet = (GameObject)Resources.Load("Prefabs/RangedBullet", typeof(GameObject));
            bullet.GetComponent<Bullet_Move>().dmg_unit += 1;
            ranged.GetComponent<Unit_Health>().health += 1;
            ranged.GetComponent<Shoot>().bullet = bullet;
            ranged.GetComponent<Shoot>().speed -= 1;
            spawn.ranged_price += 1;
            ranged_price.text = spawn.ranged_price.ToString();
            spawn.ranged = ranged;
            coins.wallet -= 5;
        } else {
            error_msg.SetActive(true);
        }
    }

    public void upgrade_shield(){
        if (coins.wallet >= 8){
            error_msg.SetActive(false);
            shield = (GameObject)Resources.Load("Prefabs/ShieldUpgrade", typeof(GameObject));
            shield.GetComponent<Unit_Health>().health += 5;
            spawn.shield_price += 3;
            spawn.shield = shield;
            shield_price.text = spawn.shield_price.ToString();
            coins.wallet -= 8;
        } else {
            error_msg.SetActive(true);
        }
    }
}
