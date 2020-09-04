using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    public float timeBetweenSpawns = 0.05f;
    public float startTimeBetweenSpawns = 0.05f;

    public GameObject jump_echo_right;
    public GameObject jump_echo_left;
    public GameObject stagger_right;
    public GameObject stagger_left;

    private playerMovement player_move;

    void Start()
    {
        player_move = GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_move.isMidAir)
        {
            if (timeBetweenSpawns <= 0)
            {
                GameObject animate_sprite;
                if (player_move.inPlay)
                {
                    animate_sprite = player_move.isFacingRight ? jump_echo_right : jump_echo_left;
                }   else
                {
                    animate_sprite = player_move.isFacingRight ? stagger_right : stagger_left;
                }
                animate_sprite.transform.rotation = transform.rotation;
                GameObject instance = Instantiate(animate_sprite, transform.position, Quaternion.identity);
                Destroy(instance, .5f);
                timeBetweenSpawns = startTimeBetweenSpawns;
            }
            else
            {
                timeBetweenSpawns -= Time.deltaTime;
            }
        }
        
    }
}
