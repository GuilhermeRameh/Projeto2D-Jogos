using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Unit : MonoBehaviour
{ 
    public GameObject origin;
    public GameObject ranged;
    public GameObject melee;
    private Menu_Controller menuController;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("Canvas").GetComponent<Menu_Controller>();
    }

    // Update is called once per fSrame
    void Update()
    {
        if(menuController.win == false){
            spawn();
        }
    }

    void spawn()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            Instantiate(melee, origin.transform.position, Quaternion.identity);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)){
            Instantiate(ranged, origin.transform.position, Quaternion.identity);
        }
    }
}
