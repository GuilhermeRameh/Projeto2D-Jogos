using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    void Awake() { instance = this; }

    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (wkManager.InWindow()==false)
        {
            GetComponent<Camera>().orthographicSize = 7f;
            transform.position = player.transform.position + offset;
        }
        else
        {
            transform.position = new Vector3(30, 10, -10);
            GetComponent<Camera>().orthographicSize = 16f;
        }
    }
}
