using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController3Dim : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0.82f, -1.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
