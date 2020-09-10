using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ground_warning : MonoBehaviour
{
    public GameObject player;
    public Image warningPanel;
    private Text warningText;
    private Transform player_transform;
    private playerMovement player_move_script;
    private bool nonvisibleDebounce = false;
    private void Start()
    {
        warningText = gameObject.GetComponent<Text>();
        player_transform = player.GetComponent<Transform>();
        player_move_script = player.GetComponent<playerMovement>();
    }

    private void FixedUpdate()
    {
        if (!nonvisibleDebounce) {
            nonvisibleDebounce = true;
            warningText.text = "";
            warningPanel.enabled = false;
        }
        if (player_move_script.inPlay && player_transform.position.y <= 10)
        {
            nonvisibleDebounce = false;
            warningPanel.enabled = true;
            warningText.text = "Warning - approaching ground in ";
            warningText.text += ((int)player_transform.position.y).ToString() + " meters.\nvvvvvv";
        }    
    }
}
