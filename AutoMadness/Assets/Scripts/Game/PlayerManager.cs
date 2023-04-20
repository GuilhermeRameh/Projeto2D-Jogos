using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerManager : MonoBehaviour
{
    public float speed = 700;
    Rigidbody2D rb;
    Vector2 move;
    public Animator animator;
    bool lookingRight = true;
    public GameObject e_key;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        e_key.transform.position = transform.position + new Vector3(1, 2, 1);
        rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);
        animator.SetFloat("speed", Math.Abs(rb.velocity[0]));
    }

    // void Update()
    // {
    //     move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    // }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
        if (move.x < 0 && lookingRight)
        {
            lookingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (move.x > 0 && !lookingRight)
        {
            lookingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
