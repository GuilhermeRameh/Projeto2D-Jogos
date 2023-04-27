using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Turret : MonoBehaviour
{
    public GameObject unit;
    public int mode; // 0 = hit enemy, 1 = hit unit
    private GameObject goal;
    public float speed;
    public float dmg_unit;
    public float dmg_enemy;

    private float timer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(0, 0);
        unit = GameObject.Find("Turret_Ally");

        //if (unit.gameObject.CompareTag("Enemy"))
        //{
        //    goal = GameObject.FindGameObjectWithTag("Unit");
        //    direction = goal.transform.position + unit.transform.position;
        //    rb.velocity = new Vector2(direction.y, direction.x).normalized * speed;
        //}
        //else
        //{
        //    goal = GameObject.FindGameObjectWithTag("Enemy");
        //    direction = goal.transform.position - unit.transform.position;
        //    rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        //}

        goal = GameObject.FindGameObjectWithTag("Enemy");
        direction = goal.transform.position - unit.transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && mode == 0){
            other.gameObject.GetComponent<Enemy_Health>().health -= dmg_unit;
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Unit") && mode == 1){
            other.gameObject.GetComponent<Unit_Health>().health -= dmg_enemy;
            Destroy(gameObject);
        }
    }
}
