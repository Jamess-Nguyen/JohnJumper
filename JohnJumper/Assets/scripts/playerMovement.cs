using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Sprite wallhang;
    public Sprite midair;
    public float speed = 5;
    public bool isFacingRight = true;

    private bool isMidAir = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float x_axis = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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


    // Called whenever a collider begins colliding with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //UnityEngine.Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Wall")
        {
            sr.sprite = wallhang;
            if (collision.collider.name == "LeftWall")
            {
                isFacingRight = true;
                sr.flipX = false;
            }   else
            {
                isFacingRight = false;
                sr.flipX = true;
            }
        }
    }


    // Called whenever a collider stops colliding with an object
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            sr.sprite = midair;
            //if (collision.collider.name == "LeftWall")
            //{
            //    isFacingRight = true;
            //    sr.flipX = false;
            //}
            //else
            //{
            //    isFacingRight = false;
            //    sr.flipX = true;
            //}
        }
    }
}
