using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Build;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public bool Left = true;
    public bool Right = false;
    public bool playMovement = true;
    public static float jump = 0;
    public GameObject Camera;
    public GameObject ScrollingGameObject;
    private Transform CameraPY;
    private Rigidbody2D rb;
    private Scrolling scroll;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CameraPY = Camera.GetComponent<Transform>();
        scroll = ScrollingGameObject.GetComponent<Scrolling>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {

        try
        {
            if (transform.position.y < CameraPY.position.y - 20)
            {
                playMovement = false;
            }
        }
        catch
        {
            playMovement = false;
        }


        if (playMovement == true)
        {
            if (Input.GetButton("Jump"))
            {
                if (Left == true)
                {
                    rb.AddForce(new Vector3(50, 50, 0), ForceMode2D.Impulse);
                    Left = false;

                }
                else if (Right == true)
                {
                    rb.AddForce(new Vector3(-50, 50, 0), ForceMode2D.Impulse);
                    Right = false;

                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "WallLeft")
        {
            Left = true;
            Right = false;
            Debug.Log("LeftWall");
            jump = jump + (float).5;

        }
        if (collision.collider.name == "WallRight")
        {
            Right = true;
            Left = false;
            Debug.Log("RightWall"); 
            jump = jump + (float).5;
            Debug.Log(jump);
        }
    }
}
