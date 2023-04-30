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
    public Level_Manager level;
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
    }

    void spawn(int level)
    {   
        int rand = Random.Range(0, 10);

        if (level == 1){
            if (rand < 5){
                Instantiate(melee, origin.transform.position, Quaternion.identity);
            } else if (rand >= 5){
                Instantiate(ranged, origin.transform.position, Quaternion.identity);
            }
        } else if (level == 2){
            if (rand < 7){
                Instantiate(melee, origin.transform.position, Quaternion.identity);
            } else if (rand >= 7){
                Instantiate(ranged, origin.transform.position, Quaternion.identity);
            }
        } else if (level == 3){
            if (rand < 5){
                Instantiate(melee, origin.transform.position, Quaternion.identity);
            } else if (rand >= 5){
                Instantiate(ranged, origin.transform.position, Quaternion.identity);
            }
        }
    }
}
