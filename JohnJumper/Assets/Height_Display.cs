using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Height_Display : MonoBehaviour
{
    public Text display_text;
    public GameObject playerCharacter;
    public GameObject ground;
    private Transform p_transform;
    private Transform g_transform;
    public int Yoffset = 2;

    // Called once at the start
    private void Start()
    {
        p_transform = playerCharacter.GetComponent<Transform>();
        g_transform = ground.GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        int diffY = (int)(p_transform.position.y - g_transform.position.y - Yoffset);
        //Debug.Log("diffY: " + diffY.ToString());
        display_text.text = "Height: " + diffY.ToString();
    }
}
