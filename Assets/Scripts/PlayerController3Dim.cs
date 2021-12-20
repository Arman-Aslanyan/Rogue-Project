using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3Dim : MonoBehaviour
{
    public float speed = 500;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xspeed = Input.GetAxisRaw("Horizontal") * speed;
        float yspeed = Input.GetAxisRaw("Vertical") * speed;

        rb.AddForce(Vector2.right * xspeed * Time.deltaTime);
        rb.AddForce(Vector2.up * yspeed * Time.deltaTime);
    }
}
