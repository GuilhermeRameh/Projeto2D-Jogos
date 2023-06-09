using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; 

public class wkManager : MonoBehaviour
{
    public wkManager instance;
    void Awake() { instance = this; }

    public GameObject e_key;

    public List<Collider2D> workStations;
    private int wsId = -1;
    public static bool in_window = false;

    public List<GameObject> WSMenus;
    public List<GameObject> maps;

    private Currency coins;
    private GameObject coin_image;
    private GameObject error_msg;

    public void Start(){
        coins = GameObject.Find("Money").GetComponent<Currency>();
        coin_image = GameObject.Find("Coins");
        error_msg = GameObject.Find("ErrorMsg");
        coins.money.enabled = false;
        coin_image.SetActive(false);
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="WK")
        {
            wsId = int.Parse(collider.name.Split("WS")[1]);
            maps[wsId].SetActive(true);
            e_key.SetActive(true);
            // Debug.Log(wsId);
        }
        if(collider.tag=="window_collider")
        {
            in_window = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag=="WK")
        {
            WSMenus[wsId].SetActive(false);
            maps[wsId].SetActive(false);
            e_key.SetActive(false);
            coins.money.enabled = false;
            coin_image.SetActive(false);
            error_msg.SetActive(false);
            wsId = -1;
        }
        else
        {
            in_window = false;
        }
    }

    void OldInputSystem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (wsId != -1)
            {
                Popup();
                // Debug.LogFormat("Abre o Menu {0}", wsId);
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        OldInputSystem();
    }

    void Popup()
    {
        WSMenus[wsId].SetActive(true);
        coins.money.enabled = true;
        coin_image.SetActive(true);
    }
    public void ClosePopup()
    {
        WSMenus[wsId].SetActive(false);
        coins.money.enabled = false;
        coin_image.SetActive(false);
        error_msg.SetActive(false);
    }

    public static bool InWindow()
    {
        return in_window;
    }

}
