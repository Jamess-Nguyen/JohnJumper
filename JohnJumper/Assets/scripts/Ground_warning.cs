using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground_warning : MonoBehaviour
{
    public GameObject player;

    private Text warningText;
    private Transform player_transform;
    private playerMovement player_move_script;

    private void Start()
    {
        warningText = gameObject.GetComponent<Text>();
        player_transform = player.GetComponent<Transform>();
        player_move_script = player.GetComponent<playerMovement>();
    }

    private void FixedUpdate()
    {
        warningText.text = "";
        if (player_move_script.inPlay && player_transform.position.y <= 10)
        {
            warningText.text = "Warning - approaching ground in ";
            warningText.text += ((int)player_transform.position.y).ToString() + " meters.\nvvvvvv";
        }    
    }
}
