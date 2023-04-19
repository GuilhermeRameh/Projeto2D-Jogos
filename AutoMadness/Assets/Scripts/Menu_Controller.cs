using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Código baseado no tutorial Unity Roll a Ball e a série de tutoriais de KeySmash Studios no Youtube (https://www.youtube.com/watch?v=__wAQOSqIaw&list=PLAt-r11PZmRmaTqYA-JhcGpZretwRxq8z)

public class Menu_Controller : MonoBehaviour
{
    public GameObject EndGamePanel;
    public bool end;

    void Start()
    {
        end = false;
        EndGamePanel.SetActive(false);

    }

    public void WinGame()
    {
        EndGamePanel.SetActive(true);
        EndGamePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Enemy Defeated! <br> <br> Press R to restart";
        end = true;
    }

    public void LoseGame()
    {
        EndGamePanel.SetActive(true);
        EndGamePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game Over! <br> <br> Press R to restart";
        end = true;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update(){
        if (end){
            if (Input.GetKeyDown(KeyCode.R)){
                Restart();
            }
        }
    }

}
