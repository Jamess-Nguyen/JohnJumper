using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    Rigidbody2D player_rb;

    void Awake() {
        player_rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (player_rb.velocity.y < 0) {
            player_rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (player_rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            player_rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
