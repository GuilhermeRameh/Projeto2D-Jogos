using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{ 
    public GameObject origin;
    public GameObject ranged;
    public GameObject melee;
    private Menu_Controller menuController;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        Instantiate(melee, origin.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(menuController.end == false){
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                spawn();
                timer = 0;
            }
        }
    }

    void spawn()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0){
            Instantiate(melee, origin.transform.position, Quaternion.identity);
        } else if (rand == 1){
            Instantiate(ranged, origin.transform.position, Quaternion.identity);
        }
    }
}
