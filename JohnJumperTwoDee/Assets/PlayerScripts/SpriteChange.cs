using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class SpriteChange : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite LeftWall, RightWall, LeftJump, RightJump, LightDead, Dead;
    public Rigidbody2D Player;
    public BasicMovement BMscript;
    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        LeftWall = Resources.Load<Sprite>("WallClingLeft");
        RightWall = Resources.Load<Sprite>("WallClingRight");
        RightJump = Resources.Load<Sprite>("RightJumping");
        LeftJump = Resources.Load<Sprite>("LeftJumping");
        rend.sprite = LeftWall;
    }

    // Update is called once per frame
    void Update()
    {
        if(BMscript.Left == true)
        {
            rend.sprite = LeftWall;
        }
        else if(BMscript.Right == true)
        {
            rend.sprite = RightWall;
        }
        else if(Player.velocity.x > 0f)
        {
            rend.sprite = RightJump;
        }
        else if(Player.velocity.x < 0f)
        {
            rend.sprite = LeftJump;
        }
    }
}
