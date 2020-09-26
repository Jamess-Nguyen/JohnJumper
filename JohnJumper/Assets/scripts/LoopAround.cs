using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAround : MonoBehaviour
{
    public GameObject yPositionStart_marker;
    public GameObject yPositionEnd_marker;
    public GameObject citySkyline;
    public GameObject ground;
    public int numLoops = 0;
    public int adjustedLoopHeight = 0;

    private float yPositionStart;
    private float yPositionEnd;
    private Transform playerTransform;
    private SpriteRenderer cityRender;
    private SpriteRenderer groundRender;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        yPositionStart = yPositionStart_marker.GetComponent<Transform>().position.y;
        yPositionEnd = yPositionEnd_marker.GetComponent<Transform>().position.y;
        cityRender = citySkyline.GetComponent<SpriteRenderer>();
        groundRender = ground.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (numLoops > 0) {
            cityRender.enabled = false;
            groundRender.enabled = false;
        } else {
            cityRender.enabled = true;
            groundRender.enabled = true;
        }
    }
    void FixedUpdate()
    {
        if (playerTransform.position.y >= yPositionEnd)
        {
            numLoops++;
            playerTransform.position = new Vector3(playerTransform.position.x, yPositionStart+.5f);
        }
        if (numLoops > 0 && playerTransform.position.y <= yPositionStart)
        {
            numLoops--;
            playerTransform.position = new Vector3(playerTransform.position.x, yPositionEnd-.5f);
        }
    }
}
