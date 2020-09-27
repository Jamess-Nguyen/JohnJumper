using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Translation : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        speed = Random.Range(4, 11);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        if(transform.position.x > 29)
        {
            speed = speed * -1.0f;
        }
        if(transform.position.x < -29)
        {
            speed = speed * -1.0f;
        }
    }
}
