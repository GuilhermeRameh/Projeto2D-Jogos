using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject goal;
    public float speed;

    private float distance;
    public float range;
    private Menu_Controller menuController;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("Canvas").GetComponent<Menu_Controller>();
        goal = GameObject.FindGameObjectWithTag("Goal");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, goal.transform.position);
        
        if (distance > range && menuController.win == false){
            transform.position = Vector2.MoveTowards(this.transform.position, goal.transform.position, speed * Time.deltaTime);
        }
    }
}
