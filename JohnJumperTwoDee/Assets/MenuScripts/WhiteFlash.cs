using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFlash : MonoBehaviour
{
    private float Frames = 0;
    private bool FlashOnce = true;
    public bool PostFlash = false;
    public GameObject Player;
    public BasicMovement BM;
    public GameObject Canvas;
    public FollowPlayer Camera;
    // Update is called once per frame
    private void Start()
    {
        Canvas.SetActive(false);
    }
    void Update()
    {
        if (FlashOnce == true)
        {
            if (BM.playMovement == false)
            {
                Canvas.SetActive(true);
                Frames += 1*Time.deltaTime;
            }
        }
        if (Frames >= .10)
        {
            Frames = 0;
            Canvas.SetActive(false);
            FlashOnce = false;
            PostFlash = true;
            Camera.enabled = false;
        }

    }
}
