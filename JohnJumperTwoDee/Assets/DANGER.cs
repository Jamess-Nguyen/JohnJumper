using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DANGER : MonoBehaviour
{
    public Transform Camera;
    public GameObject PlayerObject;
    public Text dangerText;
    public bool Movement = true;

    // Update is called once per frame
    private void Start()
    {
        dangerText.text = "";
    }

    private void Update()
    {
        if (PlayerObject.transform.position.y > 240)
        {
            if (PlayerObject.transform.position.y < Camera.position.y - 8)
            {
                dangerText.text = "DEAD!";
            }
            else if (PlayerObject.transform.position.y < Camera.position.y - 7)
            {
                dangerText.text = "DANGER!";
            }
            else
            {
                dangerText.text = "";
            }
        }

    }
}
