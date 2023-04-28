using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    void Awake() { instance = this; }

    public GameObject player;
    private Vector3 offset;
    private GameObject goal_health;
    private GameObject spawn_health;
    private GameObject coin;
    private GameObject money;

    // Start is called before the first frame update
    void Start()
    {
        goal_health = GameObject.Find("EnemyHealth");
        spawn_health = GameObject.Find("AllyHealth");
        coin = GameObject.Find("Coins_Main");
        money = GameObject.Find("Money_Main");

        goal_health.SetActive(false);
        spawn_health.SetActive(false);
        coin.SetActive(false);
        money.SetActive(false);

        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (wkManager.InWindow()==false)
        {
            GetComponent<Camera>().orthographicSize = 7f;
            transform.position = player.transform.position + offset;
            goal_health.SetActive(false);
            spawn_health.SetActive(false);
            coin.SetActive(false);
            money.SetActive(false);
        }
        else
        {
            transform.position = new Vector3(30, 14, -10);
            GetComponent<Camera>().orthographicSize = 20f;
            goal_health.SetActive(true);
            spawn_health.SetActive(true);
            coin.SetActive(true);
            money.SetActive(true);
        }
    }
}
