using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public GameObject unit;
    public int mode; //0 = unit, 1 = enemy
    public float speed;
    public List<GameObject> target = new List<GameObject>();
    public GameObject close_target;

    private float timer;
    private Menu_Controller menuController;
    private Upgrades upgrades;
    private Vector3 pos;
    private GameObject goal;
    //private float range;

    // Start is called before the first frame update
    void Start()
    {
        unit = GameObject.Find("Turret_Ally");
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (menuController.end == false)
        {
            close_target = target.OrderBy(go => go.transform.position.x).FirstOrDefault();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Enemy")){
            target.Add(other.gameObject);
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
