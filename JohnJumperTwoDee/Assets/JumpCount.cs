using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpCount : MonoBehaviour
{
    private static float jump;
    public Text jumpText;

    // Update is called once per frame
    void Update()
    {
        jump = BasicMovement.jump;
        jumpText.text = "Jump : " + jump;
    }
}
