using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wkManager : MonoBehaviour
{
    public List<Collider2D> workStations;
    private int wsId = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // public void OnTriggerEnter2D(Collider2D collider)
    // {
    //     if(collider.tag=="WK")
    //     {
    //         Debug.Log("Colidiu");
    //         collider.OnCollisionStay();
    //     }
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision:");
        if (collision.gameObject.tag == "WK")
        {
            Debug.Log("AAAAAAAAAAAA");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
