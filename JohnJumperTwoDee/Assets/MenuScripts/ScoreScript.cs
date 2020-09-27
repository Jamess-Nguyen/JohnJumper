using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public PlayerHeight Height;

    // Update is called once per frame
    void Update()
    {
        if(name == "HighScore")
        {
            txt.text = PlayerHeight.HighScore.ToString();
        }   
        if(name == "Height")
        {
            txt.text = Height.PeakHeight.ToString();
        }
    }
}
