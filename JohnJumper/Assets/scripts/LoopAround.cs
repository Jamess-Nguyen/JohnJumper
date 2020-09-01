using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAround : MonoBehaviour
{
    public float yPositionStart = -40f;
    public float yPositionEnd = 40f;
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
            playerTransform.position = new Vector3(playerTransform.position.x, yPositionStart);
        }
    }
}
