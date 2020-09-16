using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = .125f;
    public Vector3 loopOffSet;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPositon = new Vector3(0, player.position.y, 0) + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPositon, smoothSpeed);
        transform.position = smoothPosition;

    }
}
