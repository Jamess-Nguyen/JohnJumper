using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoScript : MonoBehaviour
{
    public float timeBtwSpawns;
    public float startTimeBtwnSpawns;

    public GameObject echo;
    private Rigidbody2D player;
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(player.velocity != new Vector2(0,0))
        {
            if (timeBtwSpawns <= 0)
            {
                Instantiate(echo, transform.position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwnSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }

    }
}
