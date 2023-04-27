using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missil : MonoBehaviour
{
    private GameObject goal;
    public int mode; // 0 = goal, 1 = spawn
    public float speed;

    private float distance;
    private Menu_Controller menuController;
    private Rigidbody2D rb;
    private GameObject unit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = new Vector3(0, 0, 0);

        if (mode == 1)
        {
            goal = GameObject.FindGameObjectWithTag("Spawn");
            unit = GameObject.FindGameObjectWithTag("Goal");
            direction = goal.transform.position + unit.transform.position;
            rb.velocity = new Vector2(direction.y, direction.x).normalized * speed;
        }
        else
        {
            goal = GameObject.FindGameObjectWithTag("Goal");
            unit = GameObject.FindGameObjectWithTag("Spawn");
            direction = goal.transform.position - unit.transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        }

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal")  && mode == 0)
        {
            other.gameObject.GetComponent<Goal_Health>().health -= 5;
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1){
            other.gameObject.GetComponent<Spawn_Health>().health -= 5;
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Unit") && mode == 0){
            if(other.gameObject.GetComponent<Shield>()){
                other.gameObject.GetComponent<Unit_Health>().health -= 5;
                Destroy(gameObject);
            }
        } else if (other.gameObject.CompareTag("Enemy") && mode == 1){
            if(other.gameObject.GetComponent<Shield>()){
                other.gameObject.GetComponent<Enemy_Health>().health -= 5;
                Destroy(gameObject);
            }
        }
    }
}
