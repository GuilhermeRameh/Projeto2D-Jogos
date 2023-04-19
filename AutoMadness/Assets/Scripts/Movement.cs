using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject goal;
    public float speed;
    private float maxSpeed;
    public int mode; // 0 = goal, 1 = spawn

    private float distance;
    public float range;
    private Menu_Controller menuController;
    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = speed;
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        if (mode == 0){
            goal = GameObject.FindGameObjectWithTag("Goal");
        } else if (mode == 1){
            goal = GameObject.FindGameObjectWithTag("Spawn");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, goal.transform.position);
        
        if (distance > range && menuController.end == false){
            transform.position = Vector2.MoveTowards(this.transform.position, goal.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal") && mode == 0)
        {
            speed = 0;
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1)
        {
            speed = 0;
        } else if (other.gameObject.CompareTag("Enemy") && mode == 0)
        {
            speed = 0;
        } else if (other.gameObject.CompareTag("Unit") && mode == 1)
        {
            speed = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal") && mode == 0)
        {
            speed = maxSpeed;
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1)
        {
            speed = maxSpeed;
        } else if (other.gameObject.CompareTag("Enemy") && mode == 0)
        {
            speed = maxSpeed;
        } else if (other.gameObject.CompareTag("Unit") && mode == 1)
        {
            speed = maxSpeed;
        }
    }
}
