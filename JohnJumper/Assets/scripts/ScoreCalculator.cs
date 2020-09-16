using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public GameObject playerCharacter;
    public GameObject ground;
    private Transform p_transform;
    private Transform g_transform;
    public int Yoffset = 2;
    public int heightFromGround = 0;
    public int maxHeightFromGround = 0;
    public int playerHeight = 0;
    // Start is called before the first frame update
    void Start()
    {
        p_transform = playerCharacter.GetComponent<Transform>();
        g_transform = ground.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        heightFromGround = (int)(p_transform.position.y - (g_transform.position.y + (g_transform.localScale.y/2)) - Yoffset);
        playerHeight = (int)playerCharacter.transform.position.y;
        
        if (heightFromGround > maxHeightFromGround) maxHeightFromGround = heightFromGround;
    }
}
