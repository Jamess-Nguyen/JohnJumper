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
        camTransform = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player
        camTransform.position = new Vector3(camTransform.position.x, 
            player.transform.position.y + CameraYOffset,
            camTransform.position.z);
    }
}
