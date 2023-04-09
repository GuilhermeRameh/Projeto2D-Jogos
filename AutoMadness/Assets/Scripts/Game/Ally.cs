using System.Collections;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public int health, atkPower;
    public float movespeed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(transform.right*movespeed*Time.deltaTime);
    }

    public void LoseHealth()
    {
        health--;
        StartCoroutine(BlinkRed());
        if(health<=0)
            Destroy(gameObject);

    }

    IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }


}
