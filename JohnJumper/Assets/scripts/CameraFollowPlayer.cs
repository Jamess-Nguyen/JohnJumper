using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    [Range(0f, 2f)]
    public float CameraYOffset = 2f;

    void Start()
    {
        Screen.SetResolution(1280, 720, false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,
            playerTransform.position.y + CameraYOffset,
            transform.position.z);
    }
}
