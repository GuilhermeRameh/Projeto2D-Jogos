using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Health : MonoBehaviour
{
    public float health;
    private float maxHealth;
    public Image healthBar;

    private Menu_Controller menuController;

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.Find("Canvas").GetComponent<Menu_Controller>();
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            menuController.LoseGame();
            gameObject.SetActive(false);
        }
    }
}
