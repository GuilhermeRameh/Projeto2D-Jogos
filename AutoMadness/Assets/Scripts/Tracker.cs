using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public List<GameObject> enemy_list = new List<GameObject>();
    public GameObject tracker;
    public GameObject enemy;

    private Vector2 pos;
    private Vector2 update;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.Find("Field");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemy_list.Count; i++){
            if (enemy_list[i] == null){
                enemy_list.RemoveAt(i);
                Destroy(tracker.transform.GetChild(i).gameObject);
            } else {
                update = new Vector2(enemy_list[i].transform.position.x*4.66f-140, 120);
                tracker.transform.GetChild(i).transform.position = update;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Enemy")){
            enemy_list.Add(other.gameObject);
            pos = new Vector2(140, 120);
            Instantiate(enemy, pos, Quaternion.identity).transform.parent=tracker.transform;
        }
    }
}
