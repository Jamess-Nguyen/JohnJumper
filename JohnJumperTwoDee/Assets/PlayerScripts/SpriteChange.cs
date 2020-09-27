using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.WSA;

public class SpriteChange : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite Idle, Jumper, Wallcling, Stagger, Dead;
    public Rigidbody2D Player;
    public BasicMovement BMscript;
    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Idle = Resources.Load<Sprite>("idle");
        Jumper = Resources.Load<Sprite>("Jumper");
        Wallcling = Resources.Load<Sprite>("wallcling");
        Stagger = Resources.Load<Sprite>("PlayerStagger");
        Dead = Resources.Load<Sprite>("PlayerDead");
    }

    // Update is called once per frame
    void Update()
    {
        if(BMscript.OnFloor == true)
        {
            rend.sprite = Idle;
        }

        else if(BMscript.playMovement == false)
        {
            rend.sprite = Stagger;
        }

        else if (Vector2.Dot(Player.velocity, Vector2.right) > 0 && BMscript.playMovement == true)
        {
            rend.sprite = Jumper;
            if(rend.flipX == true)
            {
                rend.flipX = false;
            }
        }
        else if (Vector2.Dot(Player.velocity, Vector2.right) < 0 && BMscript.playMovement == true)
        {
            rend.sprite = Jumper;
            if(rend.flipX == false)
            {
                rend.flipX = true;
            }
        }

        else if (Vector2.Dot(Player.velocity, Vector2.right) == 0 && BMscript.playMovement == true && BMscript.Left == true)
        {
            rend.sprite = Wallcling;
            if (rend.flipX == true)
            {
                rend.flipX = false;
            }
        }

        else if (Vector2.Dot(Player.velocity, Vector2.right) == 0 && BMscript.playMovement == true && BMscript.Right == true)
        {
            rend.sprite = Wallcling;
            if (rend.flipX == false)
            {
                rend.flipX = true;
            }
        }

    }
}
