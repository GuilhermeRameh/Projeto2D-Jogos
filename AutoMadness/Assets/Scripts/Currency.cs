using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public int wallet;
    public TextMeshProUGUI money;
    public TextMeshProUGUI money_main;
    private Level_Manager level;
    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Level").GetComponent<Level_Manager>();
        wallet = level.wallet;
    }

    // Update is called once per frame
    void Update()
    {
        money.text = wallet.ToString();
        money_main.text = wallet.ToString();
    }
}
