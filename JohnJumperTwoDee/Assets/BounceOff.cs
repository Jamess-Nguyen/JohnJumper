using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BounceOff : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform playerTransform;
    private void Start()
    {
        rb = rb.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerTransform.position.y < transform.position.y - transform.localScale.y/2 || playerTransform.position.y < transform.position.y + transform.localScale.y / 2)
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0f);
        }
        else
        {
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, 0f);
        }
    }
}
