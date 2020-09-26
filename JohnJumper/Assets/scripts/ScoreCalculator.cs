using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public GameObject ground;
  
    public int groundOffset = 6;
    public int Yoffset = 2;
    public int heightFromGround = 0;
    public int maxHeightFromGround = 0;
    public int playerHeight = 0;

    private LoopAround player_loop;
    private Transform p_transform;
    private Transform g_transform;
    
    // Start is called before the first frame update
    void Start()
    {
        player_loop = GetComponent<LoopAround>();
        p_transform = GetComponent<Transform>();
        g_transform = ground.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        heightFromGround = (int)(p_transform.position.y - (g_transform.position.y + (g_transform.localScale.y/2)) - Yoffset - groundOffset);
        heightFromGround /= 2; // unity units too small, count by 2's instead
        heightFromGround += player_loop.numLoops * 93; // remember that we're counting by 2's
        playerHeight = (int)transform.position.y;
        
        if (heightFromGround > maxHeightFromGround) maxHeightFromGround = heightFromGround;
    }
}
