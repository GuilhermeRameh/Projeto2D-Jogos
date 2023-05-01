using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal_Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    private Menu_Controller menuController;
    private Level_Manager level;

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("MenuCanvas").GetComponent<Menu_Controller>();
        level = GameObject.Find("Level").GetComponent<Level_Manager>();
        health = level.goal_health;
        maxHealth = health;
    }

    // Update is called once per frame
    // Adaptado de "Unity UI Tutorial - Create a Health Bar in 90 Seconds" (https://www.youtube.com/watch?v=mi_SP0sippI)

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            menuController.WinGame();
            gameObject.SetActive(false);
        }
    }
}
