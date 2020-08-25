using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Sprite wallhang;
    public Sprite midair;
    public Sprite standhang;
    public Sprite stagger;
    public Sprite death;

    public float speed = 5f;
    public float jump_speed = 30f;
    public float jump_cooldown = 0.5f;
    public bool isFacingRight = true;

    private bool inPlay = true;
    private bool isMidAir = false;
    private bool isJumping = false;
    private float jump_cooldown_c = 0f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform tr;
    private float x_axis = 0;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (inPlay)
        {
            if (Input.GetButtonDown("Jump") && !isMidAir && jump_cooldown_c <= 0f)
            {
                isJumping = true;
                jump_cooldown_c = jump_cooldown;
            }

            x_axis = Input.GetAxisRaw("Horizontal"); // Returns -1 if moving left, 0 is not moving, 1 if moving right
        
            if (jump_cooldown_c > 0f)
            {
                jump_cooldown_c -= Time.deltaTime;
            }
        }

    }

    // Fixed update is called after a set time
    void FixedUpdate()
    {
        if (inPlay)
        {
            switch (x_axis)
            {
                case 1:
                    //UnityEngine.Debug.Log("Moving right!");
                    rb.AddForce(new Vector2(speed * Time.deltaTime, 0), ForceMode2D.Impulse);
                    break;
                case -1:
                    //UnityEngine.Debug.Log("Moving left!");
                    rb.AddForce(new Vector2(-speed * Time.deltaTime, 0), ForceMode2D.Impulse);
                    break;
            }
            if (isJumping)
            {
                isJumping = false;
                //UnityEngine.Debug.Log("JUMP!");
                if (isFacingRight)
                {
                    rb.AddForce(new Vector2(speed, jump_speed), ForceMode2D.Impulse);
                }   else
                {
                    rb.AddForce(new Vector2(-speed, jump_speed), ForceMode2D.Impulse);
                }
                
            }
        }
    }


    // Called whenever a collider begins colliding with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //UnityEngine.Debug.Log(collision.collider.name);
        if (inPlay)
        {
            if (collision.collider.tag == "Wall")
            {
                isMidAir = false;
                sr.sprite = wallhang;
                if (collision.collider.name == "LeftWall")
                {
                    isFacingRight = true;
                    sr.flipX = false;
                }
                else
                {
                    isFacingRight = false;
                    sr.flipX = true;
                }
            }
            else if (collision.collider.tag == "Ground")
            {
                inPlay = false;
                sr.sprite = death;
                rb.isKinematic = true;
                rb.simulated = false;
                tr.position -= new Vector3(0, 1f);
            }
        }
    }


    // Called whenever a collider stops colliding with an object
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (inPlay)
        {
            if (collision.collider.tag == "Wall")
            {
                sr.sprite = midair;
                isMidAir = true;
            }
        }   
    }
}
