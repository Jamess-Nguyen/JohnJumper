using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public Text display_Text;

    private void FixedUpdate()
    {
        float fps = Time.frameCount / Time.time;
        display_Text.text = fps.ToString("F0") + " FPS";
    }
}
