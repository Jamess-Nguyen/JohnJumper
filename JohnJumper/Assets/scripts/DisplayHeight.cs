using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHeight : MonoBehaviour
{
    public ScoreCalculator player_calc;
    public LoopAround player_loop;
    private TextMeshProUGUI heightText;
    private int adjustedLoopHeight;
    // Start is called before the first frame update
    void Start()
    {
        heightText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        adjustedLoopHeight = player_calc.heightFromGround; // + (player_loop.numLoops * 93);
        if (adjustedLoopHeight <= 0) adjustedLoopHeight = 0;
        heightText.text = adjustedLoopHeight.ToString() + " feet";
    }
}
