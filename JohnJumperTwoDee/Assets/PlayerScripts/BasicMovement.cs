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
    public bool SecondJump = false;
    public bool UpJump = true;
    public bool LeftDownJump, RightDownJump;
    public static float jump = 0;
    public GameObject Camera;
    public GameObject ScrollingGameObject;
    private Transform CameraPY;
    private Rigidbody2D rb;
    private Scrolling scroll;
    private Sounds sound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CameraPY = Camera.GetComponent<Transform>();
        scroll = ScrollingGameObject.GetComponent<Scrolling>();
        sound = GetComponent<Sounds>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //THIS IS ONE BUTTON MOVEMENT
        if (playMovement == true && SecondJump == false && UpJump == true)
        {
            if (Input.GetButton("Horizontal") )
            {
                if (Left == true)
                {
                    rb.AddForce(new Vector3(115, 115, 0), ForceMode2D.Impulse);
                    Left = false;
                    SecondJump = true;
                    RightDownJump = true;
                    UpJump = false;
                }
                else if (Right == true)
                {
                    rb.AddForce(new Vector3(-115, 115, 0), ForceMode2D.Impulse);
                    Right = false;
                    SecondJump = true;
                    LeftDownJump = true;
                    UpJump = false;
                }
            }
        }
        //END ONE BUTTON MOVEMENT

        //Angled Jump
        else if (playMovement == true && SecondJump == true && UpJump == false)
        {
            if (Input.GetButton("Vertical") && RightDownJump == true)
            {
                rb.velocity = new Vector3(0, 0, 0);
                rb.AddForce(new Vector3(150, -100, 0), ForceMode2D.Impulse);
                RightDownJump = false;
                SecondJump = false;
                UpJump = true;
            }
            else if (Input.GetButton("Vertical") && LeftDownJump == true)
            {
                rb.velocity = new Vector3 (0, 0, 0);
                rb.AddForce(new Vector3(-150, -100, 0), ForceMode2D.Impulse);
                LeftDownJump = false;
                SecondJump = false;
                UpJump = true;
            }
        }
        //End Angled Jump
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //THIS IS ONE BUTTON MOVEMENT
        if (collision.collider.tag == "WallLeft")
        {
            Left = true;
            Right = false;

        }
        if (collision.collider.tag == "WallRight")
        {
            Right = true;
            Left = false;
        }
        //END ONE BUTTON MOVEMENT

        //CHECKS IF ON FLOOR
        if (collision.collider.tag == "Floor")
        {
            OnFloor = true;
        }
        //END CHECKING ON FLOOR

        SecondJump = false;
        LeftDownJump = false;
        RightDownJump = false;
        UpJump = true;
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
