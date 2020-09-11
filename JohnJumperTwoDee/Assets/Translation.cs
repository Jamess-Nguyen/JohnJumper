using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour
{
    public float speed;

    private void Start()
    {
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(speed*Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            speed = speed * -1.0f;
        }
        print("Hi");
    }

}
