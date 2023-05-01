using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn_Enemy : MonoBehaviour
{ 
    public GameObject origin;
    public GameObject ranged;
    public GameObject melee;
    public GameObject shield;
    public GameObject tank;
    public Level_Manager level;
    private int has_tank = 0;
    private int can_spawn = 1;
    private Menu_Controller menuController;
    private float timer;
    public float speed;
    public int L;

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        level = GameObject.Find("Level").GetComponent<Level_Manager>();
        speed = level.GetComponent<Level_Manager>().enemy_spawn_speed;
        L = level.GetComponent<Level_Manager>().level;

        if (L > 2){
            Instantiate(shield, origin.transform.position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(menuController.end == false){
            timer += Time.deltaTime;
            if (timer >= speed)
            {
                spawn(L);
                timer = 0;
            }
        }

        if (L == 5 && has_tank == 0 && GameObject.FindGameObjectWithTag("Goal").GetComponent<Goal_Health>().health <= GameObject.FindGameObjectWithTag("Goal").GetComponent<Goal_Health>().maxHealth*.3f){
            level.GetComponent<Level_Manager>().enemy_health = level.GetComponent<Level_Manager>().tank_health;
            level.GetComponent<Level_Manager>().enemy_ranged_dmg = level.GetComponent<Level_Manager>().tank_dmg;
            level.GetComponent<Level_Manager>().enemy_shoot_speed = level.GetComponent<Level_Manager>().tank_shoot_speed;
            level.GetComponent<Level_Manager>().enemy_ranged_speed = level.GetComponent<Level_Manager>().tank_speed;
            Instantiate(tank, origin.transform.position, Quaternion.identity);
            has_tank = 1;
            can_spawn = 0;
        }
    }

    void spawn(int level)
    {   
        if (can_spawn == 1){
            int rand = Random.Range(0, 10);
            if (level == 1){
                if (rand == 0){
                    ;
                } else if (rand < 5){
                    Instantiate(melee, origin.transform.position, Quaternion.identity);
                } else if (rand >= 5){
                    Instantiate(ranged, origin.transform.position, Quaternion.identity);
                }
            } else if (level == 2){
                if (rand == 0){
                    ;
                } else if (rand < 7){
                    Instantiate(melee, origin.transform.position, Quaternion.identity);
                } else if (rand >= 7){
                    Instantiate(ranged, origin.transform.position, Quaternion.identity);
                }
            } else if (level == 3){
                if (rand == 0){
                    ;
                } else if (rand < 5){
                    Instantiate(melee, origin.transform.position, Quaternion.identity);
                } else if (rand >= 5){
                    Instantiate(ranged, origin.transform.position, Quaternion.identity);
                }
            } else if (level == 4){
                if (rand == 0){
                    ;
                } else if (rand < 4){
                    Instantiate(melee, origin.transform.position, Quaternion.identity);
                } else if (rand >= 4){
                    Instantiate(ranged, origin.transform.position, Quaternion.identity);
                }
            } else if (level == 5){
                if (rand < 5){
                    Instantiate(melee, origin.transform.position, Quaternion.identity);
                } else if (rand >= 5){
                    Instantiate(ranged, origin.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
