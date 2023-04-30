using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject goal;
    public GameObject unit;
    public float speed;
    private float maxSpeed;
    public int mode; // 0 = goal, 1 = spawn

    private float distance;
    public float range;
    private Menu_Controller menuController;
    private Level_Manager level;
    // Start is called before the first frame update
    void Start()
    {
        
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        level = GameObject.Find("Level").GetComponent<Level_Manager>();

        if (mode == 0){
            goal = GameObject.FindGameObjectWithTag("Goal");
            if (unit.name == "MeleeUnit(Clone)" || unit.name == "MeleeUpgrade(Clone)")
            {
                speed = level.GetComponent<Level_Manager>().unit_melee_speed;
            } else if (unit.name == "RangedUnit(Clone)" || unit.name == "RangedUpgrade(Clone)")
            {
                speed = level.GetComponent<Level_Manager>().unit_ranged_speed;
            }
        } else if (mode == 1){
            goal = GameObject.FindGameObjectWithTag("Spawn");
            if (unit.name == "EnemyMeleeUnit(Clone)")
            {
                speed = level.GetComponent<Level_Manager>().enemy_melee_speed;
            } else if (unit.name == "EnemyRangedUnit(Clone)")
            {
                speed = level.GetComponent<Level_Manager>().enemy_ranged_speed;
            }
        }

        maxSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, goal.transform.position);
        
        if (distance > range && menuController.end == false){
            transform.position = Vector2.MoveTowards(this.transform.position, goal.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal") && mode == 0)
        {
            speed = 0.01f;
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1)
        {
            speed = 0.01f;
        } else if (other.gameObject.CompareTag("Enemy") && mode == 0)
        {
            speed = 0.01f;
        } else if (other.gameObject.CompareTag("Unit") && mode == 1)
        {
            speed = 0.01f;
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
