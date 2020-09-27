using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BounceOff : MonoBehaviour
{
    public Rigidbody2D rb;
    private Transform playerTransform;
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.transform;
        rb = player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(playerTransform.position.x > transform.position.x + 6 || playerTransform.position.x < transform.position.x -6)
            {
                rb.velocity = new Vector3(-rb.velocity.x * 2, rb.velocity.y, 0f);
            }
            else if (playerTransform.position.y < transform.position.y - (transform.localScale.y / 2) || playerTransform.position.y < transform.position.y + (transform.localScale.y / 2))
            {
                rb.velocity = new Vector3(rb.velocity.x * 2, -rb.velocity.y, 0f);
            }
        }

    }
}
