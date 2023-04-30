using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{   
    private bool hit;
    private bool hit_goal;
    private float timer;
    private float timer_hit_e;
    private float timer_hit_u;
    private Menu_Controller menuController;
    public int mode; // 0 = goal, 1 = spawn
    public float dmg;
    public Animator animator;
    private Level_Manager level;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        level = GameObject.Find("Level").GetComponent<Level_Manager>();

        if (mode == 0)
        {
            dmg = level.unit_melee_dmg;
        } else if (mode == 1)
        {
            dmg = level.enemy_melee_dmg;
        }
        
        hit = false;
        hit_goal = false;
        timer = 0;
        timer_hit_e = 0;
        timer_hit_u = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit_goal == true && menuController.end == false)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {   
                if (mode == 0)
                {
                    GameObject.FindGameObjectWithTag("Goal").GetComponent<Goal_Health>().health -= dmg;
                } else if (mode == 1)
                {
                    GameObject.FindGameObjectWithTag("Spawn").GetComponent<Spawn_Health>().health -= dmg;
                }
                timer = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("Goal") && mode == 0)
        {
            hit_goal = true;
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1)
        {
            hit_goal = true;
        } else if (other.gameObject.CompareTag("Enemy") && mode == 0)
        {
            hit = true;
        } else if (other.gameObject.CompareTag("Unit") && mode == 1)
        {
            hit = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal") && mode == 0)
        {
            hit_goal = false;
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1)
        {
            hit_goal = false;
        } else if (other.gameObject.CompareTag("Enemy") && mode == 0)
        {
            hit = false;
        } else if (other.gameObject.CompareTag("Unit") && mode == 1)
        {
            hit = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && mode == 0 && hit == true)
        {
            timer_hit_u += 1;
            //Debug.Log(timer_hit);
            if (timer_hit_u >= 5)
            {   
                animator.Play("MeleeAttack");
                other.gameObject.GetComponent<Enemy_Health>().health -= 1;
                StartCoroutine(BlinkRed(other.gameObject));
                timer_hit_u = 0;
            }

            //other.gameObject.GetComponent<Enemy_Health>().health -= dmg;

        } else if (other.gameObject.CompareTag("Unit") && mode == 1 && hit == true)
        {
            timer_hit_e += 1;
            //Debug.Log(timer_hit);
            if (timer_hit_e >= 5)
            {
                animator.Play("MeleeAttack");
                other.gameObject.GetComponent<Unit_Health>().health -= 1;
                StartCoroutine(BlinkRed(other.gameObject));
                timer_hit_e = 0;
            }

            //other.gameObject.GetComponent<Unit_Health>().health -= 1;
        }
    }

    IEnumerator BlinkRed(GameObject tookDamage)
    {
        Color originalColor = tookDamage.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        tookDamage.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.02f);
        if (tookDamage != null){
            tookDamage.transform.GetChild(0).GetComponent<SpriteRenderer>().color = originalColor;
        }
    }
}
