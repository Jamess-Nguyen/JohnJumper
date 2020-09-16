using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Height_Display : MonoBehaviour
{
    public Text display_text;
    public GameObject player;
    private ScoreCalculator player_score_calc;

    // Called once at the start
    private void Start()
    {
        player_score_calc = player.GetComponent<ScoreCalculator>();
    }

    private void FixedUpdate()
    {
        int diffY = player_score_calc.heightFromGround;
        //Debug.Log("diffY: " + diffY.ToString());
        display_text.text = "Height from ground: " + player_score_calc.heightFromGround.ToString() 
                + " | Player y postion: " + player_score_calc.playerHeight.ToString();
    }
}
