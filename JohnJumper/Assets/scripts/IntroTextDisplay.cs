using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroTextDisplay : MonoBehaviour
{
    public playerMovement playerMove;
    private TextMeshProUGUI introText;

    void Start()
    {
        introText = GetComponent<TextMeshProUGUI>();    
    }

    void Update()
    {
        if (playerMove.beforeplay)
        {
            introText.enabled = true;
        } else
        {
            introText.enabled = false;
        }
    }
}
