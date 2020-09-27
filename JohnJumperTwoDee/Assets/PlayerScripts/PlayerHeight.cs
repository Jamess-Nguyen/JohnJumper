using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeight : MonoBehaviour
{
    public static int HighScore = 0;
    public int PeakHeight = 0;
    public int CurrentHeight = 0;
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {

        CurrentHeight = (int)Player.transform.position.y;

        if(CurrentHeight > PeakHeight)
        {
            PeakHeight = CurrentHeight;
        }

        if(PeakHeight > HighScore || CurrentHeight > HighScore)
        {
            HighScore = (PeakHeight > CurrentHeight) ? PeakHeight : CurrentHeight;
        }
    }
}
