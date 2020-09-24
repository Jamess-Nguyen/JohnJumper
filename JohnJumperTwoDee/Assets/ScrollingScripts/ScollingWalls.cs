using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScollingWalls : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y + 600)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 600, transform.position.z);
        }
        if (player.transform.position.y < transform.position.y - 600)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 600, transform.position.z);

        }
    }
}
