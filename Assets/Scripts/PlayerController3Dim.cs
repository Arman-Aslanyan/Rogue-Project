using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3Dim : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position * movement * moveSpeed * Time.fixedDeltaTime);
    }
}
