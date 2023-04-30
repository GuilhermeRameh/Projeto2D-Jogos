using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    public GameObject unit;
    public int mode; // 0 = hit enemy, 1 = hit unit
    private GameObject goal;
    public float speed;
    public Level_Manager level;
    public float dmg_unit;
    public float dmg_enemy;

    private float timer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Level").GetComponent<Level_Manager>();
        dmg_unit = level.unit_ranged_dmg;
        dmg_enemy = level.enemy_ranged_dmg;
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = new Vector3(0, 0, 0);

        if (unit.gameObject.CompareTag("Enemy"))
        {
            goal = GameObject.FindGameObjectWithTag("Spawn");
            direction = goal.transform.position + unit.transform.position;
            rb.velocity = new Vector2(direction.y, direction.x).normalized * speed;
        }
        else
        {
            goal = GameObject.FindGameObjectWithTag("Goal");
            direction = goal.transform.position - unit.transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        }

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal")  && mode == 0)
        {
            other.gameObject.GetComponent<Goal_Health>().health -= dmg_unit;
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1){
            other.gameObject.GetComponent<Spawn_Health>().health -= dmg_enemy;
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Enemy") && mode == 0){
            other.gameObject.GetComponent<Enemy_Health>().health -= dmg_unit;
            StartCoroutine(BlinkRed(other.gameObject));
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Unit") && mode == 1){
            other.gameObject.GetComponent<Unit_Health>().health -= dmg_enemy;
            StartCoroutine(BlinkRed(other.gameObject));
            Destroy(gameObject);
        }
    }

    IEnumerator BlinkRed(GameObject tookDamage)
    {
        Color originalColor = tookDamage.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        tookDamage.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.02f);
        if (tookDamage){
            tookDamage.transform.GetChild(0).GetComponent<SpriteRenderer>().color = originalColor;
        }
    }
}
