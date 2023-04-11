using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{   
    private bool hit;
    private float timer;
    private Menu_Controller menuController;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("Canvas").GetComponent<Menu_Controller>();
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit && menuController.win == false)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                GameObject.FindGameObjectWithTag("Goal").GetComponent<Goal_Health>().health -= 1;

                timer = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            hit = true;
        }
    }
}
