using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Código baseado no tutorial Unity Roll a Ball e a série de tutoriais de KeySmash Studios no Youtube (https://www.youtube.com/watch?v=__wAQOSqIaw&list=PLAt-r11PZmRmaTqYA-JhcGpZretwRxq8z)

public class Menu_Controller : MonoBehaviour
{
    [SerializeField]
    private LevelBools completedLevels;

    public GameObject EndGamePanel;
    public GameObject[] PauseMenu;
    public GameObject story;
    public GameObject instructions;
    public Scene currentScene;
    public bool end;
    private int level;
    private int read_story = 0;
    private int read_instructions = 0;
    public int complete = 0;

    void Start()
    {
        level = Level_Manager.instance.ReturnLevel();
        currentScene = SceneManager.GetActiveScene();
        end = false;
        
        if (level != 1){
            read_instructions = 1;
        }

        if (level > 0){
            EndGamePanel.SetActive(false);
            PauseMenu[1].SetActive(false);
        }

    }

    public void WinGame()
    {
        EndGamePanel.SetActive(true);
        EndGamePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Enemy Defeated! <br> <br> Press R to restart";
        completedLevels.Value[level-1] = true;
        complete += 1;
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update(){

        if (end){
            if (Input.GetKeyDown(KeyCode.R) && level > 0){
                Restart();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && level > 0){
            if (!end){
                if (level != 0){
                    if (PauseMenu[1].activeSelf){
                        Unpause();
                    } else {
                        Pause();
                    }
                }
            }
        }

        if (read_story == 0 || read_instructions == 0 && level > 0){
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Return) && read_story == 0 && level > 0){
            story.SetActive(false);
            read_story = 1;
            Time.timeScale = 1;
        } else if (Input.GetKeyDown(KeyCode.Return) && read_instructions == 0 && level > 0){
            instructions.SetActive(false);
            read_instructions = 1;
            Time.timeScale = 1;
        }

        if (currentScene.name == "Credits" && Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("MainMenu");
        }

        if (currentScene.name == "LevelSelection"){
            if (complete == 5){
                SceneManager.LoadScene("Credits");
            }
        }

    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenu[0].SetActive(false);
        PauseMenu[1].SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        PauseMenu[0].SetActive(true);
        PauseMenu[1].SetActive(false);
    }

    public void PlaySFX(string s)
    {
        AudioManager.instance.playAudio(s);
    }

}
