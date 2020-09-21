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
    public bool OnFloor = false;
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
        //THIS IS ONE BUTTON MOVEMENT
        if (playMovement == true)
        {
            if (Input.GetButton("Jump"))
            {
                if (Left == true)
                {
                    rb.AddForce(new Vector3(70, 70, 0), ForceMode2D.Impulse);
                    Left = false;

                }
                else if (Right == true)
                {
                    rb.AddForce(new Vector3(-70, 70, 0), ForceMode2D.Impulse);
                    Right = false;

                }
            }
        }
        //END ONE BUTTON MOVEMENT
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //THIS IS ONE BUTTON MOVEMENT
        if (collision.collider.tag == "WallLeft")
        {
            Left = true;
            Right = false;
            Debug.Log("LeftWall");
            jump = jump + (float).5;

        }
        if (collision.collider.tag == "WallRight")
        {
            Right = true;
            Left = false;
            Debug.Log("RightWall");
            jump = jump + (float).5;
            Debug.Log(jump);
        }
        //END ONE BUTTON MOVEMENT

        //CHECKS IF ON FLOOR
        if (collision.collider.tag == "Floor")
        {
            OnFloor = true;
        }
        //END CHECKING ON FLOOR
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //CHECKS LEAVING FLOOR
        if (collision.collider.tag == "Floor")
        {
            OnFloor = false;
        }
        //END CHECK LEAVING FLOOR
    }
}
