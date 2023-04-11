using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    public GameObject unit;
    private GameObject goal;
    public float speed;

    private float timer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goal = GameObject.FindGameObjectWithTag("Goal");

        Vector3 direction = goal.transform.position - unit.transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);

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
        if (other.gameObject.CompareTag("Goal"))
        {
            other.gameObject.GetComponent<Goal_Health>().health -= .5f;
            Destroy(gameObject);
        }
    }
}
