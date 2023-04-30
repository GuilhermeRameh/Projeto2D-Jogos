using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public float cooldown;
    public GameObject cooldown_bar;
    public Image cooldown_bar_Image;

    // Start is called before the first frame update
    void Start()
    {
        cooldown_bar.SetActive(false);
        cooldown = 100;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown_bar_Image.fillAmount = Mathf.Clamp(cooldown / 100, 0, 1);
    }
}
