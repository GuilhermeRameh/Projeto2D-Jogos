using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject unit;
    public int mode; //0 = unit, 1 = enemy
    public float speed;

    private float timer;
    private Menu_Controller menuController;
    private Level_Manager level;
    private Upgrades upgrades;
    private Vector3 pos;
    public Animator animator;
    private float unit_speed;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        level = GameObject.Find("Level").GetComponent<Level_Manager>();
        if (mode == 0){
            speed = level.unit_shoot_speed;
        } else if (mode == 1){
            speed = level.enemy_shoot_speed;
        }

        unit_speed = unit.GetComponent<Movement>().speed;
    }

    // Update is called once per frame
    void Update()
    {

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

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Enemy") && mode == 0){
            shoot();
        } else if (other.gameObject.CompareTag("Unit") && mode == 1){
            shoot();
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1){
            shoot();
        } else if (other.gameObject.CompareTag("Goal") && mode == 0){
            shoot();
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.CompareTag("Enemy") && mode == 0){
            if (menuController.end == false)
            {
                timer += Time.deltaTime;
                if (timer >= speed)
                {
                    // animator.Play("RangedAttack");
                    AudioManager.instance.playAudio("Shoot");
                    animator.SetTrigger("RangedAttack");
                    shoot();
                    timer = 0;
                }
            }
            
        } else if (other.gameObject.CompareTag("Unit") && mode == 1){
            if (menuController.end == false)
            {
                timer += Time.deltaTime;
                if (timer >= speed)
                {
                    // animator.Play("RangedAttack");
                    AudioManager.instance.playAudio("Shoot");
                    animator.SetTrigger("RangedAttack");
                    shoot();
                    timer = 0;
                }
            }
        } else if (other.gameObject.CompareTag("Spawn") && mode == 1){
            if (menuController.end == false)
            {
                timer += Time.deltaTime;
                if (timer >= speed)
                {
                    // animator.Play("RangedAttack");
                    AudioManager.instance.playAudio("Shoot");
                    animator.SetTrigger("RangedAttack");
                    shoot();
                    timer = 0;
                }
            }
        } else if (other.gameObject.CompareTag("Goal") && mode == 0){
            if (menuController.end == false)
            {
                timer += Time.deltaTime;
                if (timer >= speed)
                {
                    // animator.Play("RangedAttack");
                    AudioManager.instance.playAudio("Shoot");
                    animator.SetTrigger("RangedAttack");
                    shoot();
                    timer = 0;
                }
            }
        }
    }

    
}
