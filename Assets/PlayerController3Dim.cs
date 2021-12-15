using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3Dim : MonoBehaviour
{
    public float speed = 500;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xspeed = Input.GetAxisRaw("Horizontal") * speed;
        float zspeed = Input.GetAxisRaw("Vertical") * speed;

        rb.AddForce(Vector3.right * xspeed * Time.deltaTime);
        rb.AddForce(Vector3.forward * zspeed * Time.deltaTime);
    }
}
