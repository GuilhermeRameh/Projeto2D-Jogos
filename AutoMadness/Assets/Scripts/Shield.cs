using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject goal;
    private GameObject unit;
    public float speed;
    private float maxSpeed;
    public int mode; // 0 = goal, 1 = spawn

    private float distance_g;
    private float distance_e;
    private float distance;
    private float range;
    private Menu_Controller menuController;
    private Vector3 direction_g;
    private Vector3 direction_e;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = speed;
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        if (mode == 0){
            goal = GameObject.FindGameObjectWithTag("Goal");
            unit = GameObject.FindGameObjectWithTag("Enemy");
        } else if (mode == 1){
            goal = GameObject.FindGameObjectWithTag("Spawn");
            unit = GameObject.FindGameObjectWithTag("Unit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction_g = new Vector3 (goal.transform.position.x/2, goal.transform.position.y + .8f, 0);
        direction_e = new Vector3 (unit.transform.position.x, goal.transform.position.y +.8f, 0);
        distance_g = Vector2.Distance(transform.position, direction_g);
        distance_e = Vector2.Distance(transform.position, direction_e);
        
        if (distance_g > distance_e){
            distance = distance_e;
            direction = direction_e;
            range = 5;
        } else {
            distance = distance_g;
            direction = direction_g;
            range = 0;
        }

        if (distance > range && menuController.end == false){
            transform.position = Vector2.MoveTowards(this.transform.position, direction, speed * Time.deltaTime);
        }
        
    }
}
