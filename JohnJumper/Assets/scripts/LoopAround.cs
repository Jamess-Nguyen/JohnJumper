using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAround : MonoBehaviour
{
    public float yPositionStart = -40f;
    public float yPositionEnd = 40f;

    private int numLoops = 0;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (playerTransform.position.y >= yPositionEnd)
        {
            Debug.Log("LOOP!");
            numLoops++;
            playerTransform.position = new Vector3(playerTransform.position.x, yPositionStart+10f);
        }
        if (numLoops > 0 && playerTransform.position.y <= yPositionStart)
        {
            Debug.Log("UNDO LOOP!");
            numLoops--;
            playerTransform.position = new Vector3(playerTransform.position.x, yPositionEnd-10f);
        }
    }
}
