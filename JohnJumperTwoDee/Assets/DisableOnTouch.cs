using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisableOnTouch : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerPosition;
    private void Start()
    {
        playerPosition = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerPosition.AddForce(new Vector3(-20, 20, 0), ForceMode2D.Impulse);
    }
}
