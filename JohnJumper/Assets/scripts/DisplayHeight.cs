using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHeight : MonoBehaviour
{
    public ScoreCalculator player_calc;
    public LoopAround player_loop;
    public playerMovement player_move;

    private TextMeshProUGUI heightText;
    private int adjustedLoopHeight;
    // Start is called before the first frame update
    void Start()
    {
        heightText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (player_move.inPlay && !player_move.beforeplay)
        {
            heightText.enabled = true;
            adjustedLoopHeight = player_calc.heightFromGround;
            if (adjustedLoopHeight <= 0) adjustedLoopHeight = 0;
            heightText.text = adjustedLoopHeight.ToString() + " feet";
        } else
        {
            heightText.enabled = false;
        }
    }
}
