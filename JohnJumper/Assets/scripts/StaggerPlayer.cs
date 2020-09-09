using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggerPlayer : MonoBehaviour
{
    public GameObject player;
    public Sprite stagger;
    [Range(-7f, 7f)]
    public float middleX = 0;
    private SpriteRenderer player_sr;
    private playerMovement player_script;
    private Rigidbody2D player_rb;
    private Transform player_tr;
    private EchoEffect player_echo;

    private void Start()
    {
        player_sr = player.GetComponent<SpriteRenderer>();
        player_script = player.GetComponent<playerMovement>();
        player_rb = player.GetComponent<Rigidbody2D>();
        player_tr = player.GetComponent<Transform>();
        player_echo = player.GetComponent<EchoEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == player.name)
        {
            player_script.isMidAir = true;
            player_sr.sprite = stagger;
            player_sr.flipX = !player_sr.flipX;
            player_script.isFacingRight = !player_script.isFacingRight;
            player_script.inPlay = false;
            player_script.spikeBumps++;
            player_echo.enabled = false;
            if (player_tr.position.x > middleX)
            {
                player_rb.velocity = new Vector3(0f, player_rb.velocity.y > 0 ? 0 : player_rb.velocity.y);
                player_rb.AddForce(new Vector2(-3f, 0f), ForceMode2D.Impulse);
            }
            else
            {
                player_rb.velocity = new Vector3(0f, player_rb.velocity.y > 0 ? 0 : player_rb.velocity.y);
                player_rb.AddForce(new Vector2(3f, 0f), ForceMode2D.Impulse);
            }
        }   
    }
}
