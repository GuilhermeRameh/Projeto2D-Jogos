using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{   
    private bool hit;
    private bool hit_goal;
    private float timer;
    private Menu_Controller menuController;
    public int mode; // 0 = goal, 1 = spawn
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("Canvas").GetComponent<Menu_Controller>();
        hit = false;
        hit_goal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit_goal == true && menuController.end == false)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {   
                if (mode == 0)
                {
                    GameObject.FindGameObjectWithTag("Goal").GetComponent<Goal_Health>().health -= 1;
                } else if (mode == 1)
                {
                    GameObject.FindGameObjectWithTag("Spawn").GetComponent<Spawn_Health>().health -= 1;
                }
                timer = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal") && mode == 0)
        {
            hit_goal = true;
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1)
        {
            hit_goal = true;
        } else if (other.gameObject.CompareTag("Enemy") && mode == 0)
        {
            hit = true;
        } else if (other.gameObject.CompareTag("Unit") && mode == 1)
        {
            hit = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal") && mode == 0)
        {
            hit_goal = false;
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1)
        {
            hit_goal = false;
        } else if (other.gameObject.CompareTag("Enemy") && mode == 0)
        {
            hit = false;
        } else if (other.gameObject.CompareTag("Unit") && mode == 1)
        {
            hit = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && mode == 0 && hit == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                other.gameObject.GetComponent<Enemy_Health>().health -= 1;

                timer = 0;
            }

        } else if (other.gameObject.CompareTag("Unit") && mode == 1 && hit == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                other.gameObject.GetComponent<Unit_Health>().health -= 1;

                timer = 0;
            }
        }
    }
}
