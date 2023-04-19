using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public GameObject melee;
    public GameObject ranged;
    public GameObject error_msg;
    public GameObject bullet;
    public Spawn_Unit spawn;

    private Currency coins;
    private int cooldown;
    // Start is called before the first frame update
    void Start()
    {
        melee = (GameObject)Resources.Load("Prefab/Melee_Unit", typeof(GameObject));
        ranged = (GameObject)Resources.Load("Prefab/Ranged_Unit", typeof(GameObject));

        spawn = GameObject.Find("Infantry").GetComponent<Spawn_Unit>();
        coins = GameObject.Find("Money").GetComponent<Currency>();
        cooldown = 0;
        error_msg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)){
            if (coins.wallet >= 5){
                melee = (GameObject)Resources.Load("Prefab/Melee_Upgrade", typeof(GameObject));
                melee.GetComponent<Swing>().dmg += 1;
                melee.GetComponent<Unit_Health>().health += 1;
                spawn.melee_price += 1;
                spawn.melee = melee;
                coins.wallet -= 5;
            } else {
                error_msg.SetActive(true);
                cooldown = 15;
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha9)){
            if (coins.wallet >= 5){
                ranged = (GameObject)Resources.Load("Prefab/Ranged_Upgrade", typeof(GameObject));
                bullet = (GameObject)Resources.Load("Prefab/Bullet_Unit", typeof(GameObject));
                bullet.GetComponent<Bullet_Move>().dmg_unit += 1;
                ranged.GetComponent<Unit_Health>().health += 1;
                ranged.GetComponent<Shoot>().bullet = bullet;
                ranged.GetComponent<Shoot>().speed -= 1;
                spawn.ranged_price += 1;
                spawn.ranged = ranged;
                coins.wallet -= 5;
            } else {
                error_msg.SetActive(true);
                cooldown = 15;
            }
        }

        if (cooldown > 0){
            cooldown -= 1;
        } else {
            error_msg.SetActive(false);
        }
        
    }
}
