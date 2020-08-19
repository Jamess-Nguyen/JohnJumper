using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    private float x_axis = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            UnityEngine.Debug.Log("Hello World!");
        }

        x_axis = Input.GetAxisRaw("Horizontal"); // Returns -1 if moving left, 0 is not moving, 1 if moving right
    }

    // Fixed update is called after a set time
    void FixedUpdate()
    {
        switch (x_axis)
        {
            case 1:
                UnityEngine.Debug.Log("Moving right!");
                rb.AddForce(new Vector3(speed * Time.deltaTime,0,0), ForceMode2D.Impulse);
                break;
            case -1:
                UnityEngine.Debug.Log("Moving left!");
                rb.AddForce(new Vector3(-speed * Time.deltaTime, 0,0), ForceMode2D.Impulse);
                break;
        }
    }
}
