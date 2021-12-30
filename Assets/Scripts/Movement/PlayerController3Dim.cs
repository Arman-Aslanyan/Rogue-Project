using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3Dim : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public bool spokeToKnight = false;
    public bool canMove = true;
    public GameObject toCheckDist;

    // Update called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        float dist = Vector2.Distance(transform.position, toCheckDist.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && dist <= 2.5f && spokeToKnight)
            FindObjectOfType<BeginTreantFight>().BeginTheChaos(true);
    }
    private void FixedUpdate()
    {
        if (canMove)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
