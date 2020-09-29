using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAround : MonoBehaviour
{
    public GameObject yPositionStart_marker;
    public GameObject yPositionEnd_marker;
    public GameObject citySkyline;
    public GameObject ground;
    public GameObject firstSpike;

    public int numLoops = 0;
    public int adjustedLoopHeight = 0;

    private spikeGen sg;
    private float yPositionStart;
    private float yPositionEnd;
    private Transform playerTransform;
    private SpriteRenderer cityRender;
    private SpriteRenderer groundRender;
    private SpriteRenderer spikeRender1st;

    // Start is called before the first frame update
    void Start()
    {
        sg = GetComponent<spikeGen>();
        playerTransform = GetComponent<Transform>();
        yPositionStart = yPositionStart_marker.GetComponent<Transform>().position.y;
        yPositionEnd = yPositionEnd_marker.GetComponent<Transform>().position.y;
        cityRender = citySkyline.GetComponent<SpriteRenderer>();
        groundRender = ground.GetComponent<SpriteRenderer>();
        spikeRender1st = firstSpike.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (numLoops > 0) {
            spikeRender1st.enabled = false;
            cityRender.enabled = false;
            groundRender.enabled = true;
        } else {
            cityRender.enabled = true;
            groundRender.enabled = true;
            spikeRender1st.enabled = false;
        }
    }
    void FixedUpdate()
    {
        if (playerTransform.position.y >= yPositionEnd)
        {
            numLoops++;
            playerTransform.position = new Vector3(playerTransform.position.x, yPositionStart+.5f);
            sg.GenerateSpikePos();
            sg.SetSpikePos();
        }
        if (numLoops > 0 && playerTransform.position.y <= yPositionStart)
        {
            numLoops--;
            playerTransform.position = new Vector3(playerTransform.position.x, yPositionEnd-.5f);
            sg.GenerateSpikePos();
            sg.SetSpikePos();
        }
    }
}
