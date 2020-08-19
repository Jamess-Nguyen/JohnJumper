using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [Range(0f,2.5f)]
    public float CameraYOffset = 0f;
    private Vector3 vect;
    public GameObject player;
    private Transform camTransform;

    // Start is called before the first frame update
    void Start()
    {
        vect = new Vector3(0, CameraYOffset, 0);
        camTransform = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player
        camTransform.position = new Vector3(player.transform.position.x, player.transform.position.y,
            camTransform.position.z) + vect;
    }
}
