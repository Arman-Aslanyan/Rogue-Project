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
    public bool hasToCheckANDPress;
    public GameObject toCheckDist;
    public GameObject KeyToPress;

    // Update called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (hasToCheckANDPress)
        {
            float dist = Vector2.Distance(transform.position, toCheckDist.transform.position);
            if (Input.GetKeyDown(KeyCode.E) && dist <= 2.5f && spokeToKnight)
                FindObjectOfType<BeginTreantFight>().BeginTheChaos(true);
        }
    }
    private void FixedUpdate()
    {
        if (canMove)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void EnableKeyPress()
    {
        GameObject clone;
        Transform treant = FindObjectOfType<BeginTreantFight>().transform;
        clone = Instantiate(KeyToPress, treant.position + new Vector3(-1, 0, 0), Quaternion.identity);
    }

    public void DisableKeyPress()
    {
        Destroy(GameObject.Find("Tutorial Key_Press(Clone)"));
    }
}
