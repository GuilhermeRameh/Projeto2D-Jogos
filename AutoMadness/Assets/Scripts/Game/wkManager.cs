using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wkManager : MonoBehaviour
{
    public wkManager instance;
    void Awake() { instance = this; }

    public List<Collider2D> workStations;
    private int wsId = -1;
    public static bool in_window = false;

    public List<GameObject> WSMenus;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="WK")
        {
            wsId = int.Parse(collider.name.Split("WS")[1])-1;
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
                Debug.LogFormat("Abre o Menu {0}", wsId);
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
    }
    public void ClosePopup()
    {
        WSMenus[wsId].SetActive(false);
    }

    public static bool InWindow()
    {
        return in_window;
    }

}
