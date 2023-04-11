using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Código baseado no tutorial Unity Roll a Ball e a série de tutoriais de KeySmash Studios no Youtube (https://www.youtube.com/watch?v=__wAQOSqIaw&list=PLAt-r11PZmRmaTqYA-JhcGpZretwRxq8z)

public class Menu_Controller : MonoBehaviour
{
    public GameObject EndGamePanel;
    public bool win;

    void Start()
    {
        win = false;
        EndGamePanel.SetActive(false);

    }

    public void WinGame()
    {
        EndGamePanel.SetActive(true);
        win = true;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update(){
        if (win){
            if (Input.GetKeyDown(KeyCode.R)){
                Restart();
            }
        }
    }

}
