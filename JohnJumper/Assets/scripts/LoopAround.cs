using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAround : MonoBehaviour
{
    public GameObject yPositionStart_marker;
    public GameObject yPositionEnd_marker;
    public int numLoops = 0;

    private float yPositionStart;
    private float yPositionEnd;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        yPositionStart = yPositionStart_marker.GetComponent<Transform>().position.y;
        yPositionEnd = yPositionEnd_marker.GetComponent<Transform>().position.y;
    }

    void FixedUpdate()
    {
        if (playerTransform.position.y >= yPositionEnd)
        {
            numLoops++;
            playerTransform.position = new Vector3(playerTransform.position.x, yPositionStart+10f);
        }
        if (numLoops > 0 && playerTransform.position.y <= yPositionStart)
        {
            numLoops--;
            playerTransform.position = new Vector3(playerTransform.position.x, yPositionEnd-10f);
        }
    }
}
