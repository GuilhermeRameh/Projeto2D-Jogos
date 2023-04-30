using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public Scene currentScene;
    public float enemy_spawn_speed;
    public float enemy_shoot_speed;
    public float enemy_health;
    public float enemy_melee_dmg;
    public float enemy_ranged_dmg;
    public float enemy_melee_speed;
    public float enemy_ranged_speed;

    public float unit_shoot_speed;
    public float unit_melee_dmg;
    public float unit_ranged_dmg;
    public float unit_melee_speed;
    public float unit_ranged_speed;
    public int wallet;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level1"){
            enemy_spawn_speed = 6;
            enemy_shoot_speed = 2;
            enemy_melee_dmg = 1;
            enemy_ranged_dmg = .5f;
            enemy_melee_speed = 4;
            enemy_ranged_speed = 2;
            unit_shoot_speed = 2;
            unit_melee_dmg = 1.5f;
            unit_ranged_dmg = 1;
            unit_melee_speed = 5;
            unit_ranged_speed = 3;
            enemy_health = 2;
            wallet = 5;
            level = 1;

        } else if (currentScene.name == "Level2"){
            enemy_spawn_speed = 4;
            enemy_shoot_speed = 2;
            enemy_melee_dmg = 1;
            enemy_ranged_dmg = .5f;
            enemy_melee_speed = 4;
            enemy_ranged_speed = 2;
            unit_shoot_speed = 2;
            unit_melee_dmg = 1.5f;
            unit_ranged_dmg = 1;
            unit_melee_speed = 5;
            unit_ranged_speed = 3;
            enemy_health = 3;
            wallet = 10;
            level = 2;
        } else if (currentScene.name == "Level3"){
            enemy_spawn_speed = 5;
            enemy_shoot_speed = 2;
            enemy_melee_dmg = 1.5f;
            enemy_ranged_dmg = 1;
            enemy_melee_speed = 4.5f;
            enemy_ranged_speed = 2.5f;
            unit_shoot_speed = 2;
            unit_melee_dmg = 1.5f;
            unit_ranged_dmg = 1;
            unit_melee_speed = 5;
            unit_ranged_speed = 3;
            enemy_health = 3;
            wallet = 10;
            level = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
