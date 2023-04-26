using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public int wallet;
    public TextMeshProUGUI money;
    public TextMeshProUGUI money_main;
    // Start is called before the first frame update
    void Start()
    {
        wallet = 10;
    }

    // Update is called once per frame
    void Update()
    {
        money.text = wallet.ToString();
        money_main.text = wallet.ToString();
    }
}
