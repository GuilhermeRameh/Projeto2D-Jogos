using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public GameObject unit;
    public int mode; //0 = unit, 1 = enemy
    public float speed;

    private float timer;
    private Menu_Controller menuController;
    private Upgrades upgrades;
    private Vector3 pos;
    private GameObject goal;
    private float range;

    // Start is called before the first frame update
    void Start()
    {
        unit = GameObject.Find("Turret_Ally");
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        range = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (menuController.end == false)
        {
            //if (unit.gameObject.CompareTag("Enemy"))
            //{
            //    goal = GameObject.FindGameObjectWithTag("Unit");
            //    direction = goal.transform.position + unit.transform.position;
            //}
            //else
            //{
            //    goal = GameObject.FindGameObjectWithTag("Enemy");
            //    direction = goal.transform.position - unit.transform.position;
            //}

            //if (direction.magnitude <= range)
            //{
            //    timer += Time.deltaTime;
            //    if (timer >= speed)
            //    {
            //        shoot();
            //        timer = 0;
            //    }
            //}

            range += 1;
        }
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            timer += Time.deltaTime;
            if (timer >= speed)
            {
                shoot();
                timer = 0;
            }
        }

    }

    void shoot()
    {   
        if (mode == 0){
            pos = new Vector3(unit.transform.position.x + 1, unit.transform.position.y, 0);
        } else if (mode == 1){
            pos = new Vector3(unit.transform.position.x - 1, unit.transform.position.y, 0);
        }
        Instantiate(bullet, pos, Quaternion.identity);
    }
}
