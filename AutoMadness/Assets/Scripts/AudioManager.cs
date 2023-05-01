using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private Scene scene;

    public static AudioManager instance;
    public AudioSource MenusTrack;
    public AudioSource FirstBattlesTrack;
    public AudioSource BossTrack;

    public int previousTrack = 0;

    void Start()
    {
        MenusTrack.Play();
    }

    void Awake()
    {
        if (instance==null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{Destroy(gameObject);}
         
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
        scene = SceneManager.GetActiveScene();
    }

    private void OnDestroy()
    {
        // Always clean up your listeners when not needed anymore
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name ==  "MainMenu" || scene.name=="LevelSelection")
        {
            if (previousTrack != 0)
            {
                MenusTrack.Play();
                FirstBattlesTrack.Stop();
                BossTrack.Stop();
                previousTrack=0;
            }
        }
        if (scene.name=="Level1" || scene.name=="Level2" || scene.name=="Level3" || scene.name=="Level4")
        {
            if (previousTrack != 1)
            {
                FirstBattlesTrack.Play();
                BossTrack.Stop();
                MenusTrack.Stop();
                previousTrack=1;
            }
        }
        if (scene.name == "Level5")
        {
            if (previousTrack != 2)
            {
                BossTrack.Play();
                MenusTrack.Stop();
                FirstBattlesTrack.Stop();
                previousTrack=2;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            MenusTrack.Play();
        }
        if (Input.GetKeyDown(KeyCode.O)){
            MenusTrack.Stop();
        }
    }


    public void playAudio(string s)
    {
        transform.Find(s).GetComponent<AudioSource>().Play();
    }


}
