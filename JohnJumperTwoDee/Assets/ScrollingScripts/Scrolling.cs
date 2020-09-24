using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public Transform player;
    public int loopCounter = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.y >= 400)
        {
            transform.position = new Vector3(player.position.x, 200, player.position.z);
            loopCounter++;
        }
    }
}
