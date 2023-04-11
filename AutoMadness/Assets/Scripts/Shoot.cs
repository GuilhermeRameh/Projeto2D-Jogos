using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject unit;

    private float timer;
    private Menu_Controller menuController;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("Canvas").GetComponent<Menu_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (menuController.win == false)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                shoot();
                timer = 0;
            }
        }
        
    }

    void shoot()
    {
        Instantiate(bullet, unit.transform.position, Quaternion.identity);
    }
}
