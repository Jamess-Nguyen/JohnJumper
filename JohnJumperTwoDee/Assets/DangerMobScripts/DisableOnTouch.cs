using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


public class DisableOnTouch : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rbPlayer;
    private BasicMovement movePlayer;
    private BoxCollider2D boxPlayer;
    private EchoScript echoPlayer;
    private void Start()
    {
        player = GameObject.Find("Player");
        rbPlayer = player.GetComponent<Rigidbody2D>();
        movePlayer = player.GetComponent<BasicMovement>();
        boxPlayer = player.GetComponent<BoxCollider2D>();
        echoPlayer = player.GetComponent<EchoScript>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            rbPlayer.velocity = new Vector2(0, 0);
            rbPlayer.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
            movePlayer.playMovement = false;
            boxPlayer.enabled = false;
            echoPlayer.enabled = false;
        }

    }
}
