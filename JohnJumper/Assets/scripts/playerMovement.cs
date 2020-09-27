using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Sprite wallhang;
    public Sprite midair;
    public Sprite standhang;
    public Sprite stagger;
    public Sprite death;

    public int spikeBumps = 0; // how many times the player "bumped" on a spike
    [Range(1,30)]
    public float speed = 10f;
    [Range(1,40)]
    public float jumpVelocity = 15f;
    public float maxJumpVelocity = 60f;
    public float jumpCooldown = 0.5f;
    public bool isFacingRight = true;
    public bool beforeplay = true;
    public bool inPlay = false;
    public bool isMidAir = false;
    public bool isWallSliding = false;
    public float playerStartX = -12.4f;
    public float playerStartY = 15.12f;
    public float timeComboDecays = 2f;
    public float currentTimeBetweenJumps;
    public ComboDisplay player_combo_script;

    public float restartDelay = .1f; // avoid the restart, jump immediately glitch
    private float restartDelayCount = .5f; 
    private float timeDeltaSecond = 1f;
    private float comboDecayTick = .75f; // min is .75f, max is .99f
    private float minJumpVelocity;
    private bool isJumping = false;
    private float jumpCooldownC = 0f;
    private float groundDeathOffset = 3.75f;
    private int numSpikesUntilTumble = 2;
    private float timeUntilWallslideParticles = 0.3f;
    private float currentTimeUntilWallSlideParticles = 0f;
    private EchoEffect player_echo;
    private LoopAround player_looparound;
    private sounds player_sounds;
    private spikeGen sg;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform tr;
    private ParticleSystem player_pr;
    private ParticleSystem.EmissionModule player_pr_em;
    private ParticleSystem.ShapeModule player_pr_sp;

    // Start is called before the first frame update
    void Start()
    {
        restartDelayCount = restartDelay;
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sg = GetComponent<spikeGen>();
        player_pr = GetComponent<ParticleSystem>();
        player_echo = GetComponent<EchoEffect>();
        player_looparound = GetComponent<LoopAround>();
        player_sounds = GetComponent<sounds>();
        player_pr_em = player_pr.emission;
        player_pr_sp = player_pr.shape;
        currentTimeBetweenJumps = timeComboDecays;
        minJumpVelocity = jumpVelocity;
        player_pr_em.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (beforeplay)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            if (Input.GetButtonDown("Jump") && restartDelayCount < 0)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                beforeplay = false;
                inPlay = true;
            }
            restartDelayCount -= Time.deltaTime;
        }
        if (inPlay)
        {
            if (Input.GetButtonDown("Jump") && !isMidAir && jumpCooldownC <= 0f)
            {
                // Wall jump successful
                player_sounds.grunt.pitch = Random.Range(.9f, 1.1f);
                player_sounds.Grunt();
                player_combo_script.numCombos = player_combo_script.numCombos == 99 ? 99 : player_combo_script.numCombos+1;
                if (player_combo_script.numCombos >= 40) {
                    player_echo.enabled = true;
                }
                currentTimeBetweenJumps = timeComboDecays;
                isJumping = true;
                jumpCooldownC = jumpCooldown;
                timeDeltaSecond = 1f;
                comboDecayTick = .75f;
            }
            if (jumpCooldownC > 0f)
            {
                // Cannot walljump, cooldown in effect
                jumpCooldownC -= Time.deltaTime;
            }
            player_pr.transform.position = new Vector3(transform.position.x, transform.position.y, player_pr.transform.position.z);
            if (currentTimeBetweenJumps > 0) currentTimeBetweenJumps -= Time.deltaTime;
            else {
                if (timeDeltaSecond <= comboDecayTick) {
                    // decay the combo every 1/4th of a second
                    timeDeltaSecond = 1f;
                    player_combo_script.numCombos = player_combo_script.numCombos > 1 ? player_combo_script.numCombos-1 : 0;
                    jumpVelocity = jumpVelocity > minJumpVelocity ? jumpVelocity - .1f : minJumpVelocity;
                    comboDecayTick = comboDecayTick >= .99f ? .99f : comboDecayTick + .01f;
                    if (player_combo_script.numCombos < 40f) {
                        player_echo.enabled = false;
                    }
                }
                timeDeltaSecond -= Time.deltaTime;
                
            }
        }
        else if (isMidAir) {
            // Rotate the character (tumbling) if spikebumps >= 3;
            if (spikeBumps >= numSpikesUntilTumble) {
                tr.Rotate(0, 0, 1.0f, Space.Self);
            }
        }
    }

    // Fixed update is called after a set time
    void FixedUpdate()
    {
        if (inPlay)
        {
            if (isJumping)
            {
                isJumping = false;
                // jump in the direction character is facing
                if (isFacingRight)
                {
                    //rb.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
                    rb.velocity = Vector2.right * speed;
                }   else
                {
                    //rb.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
                    rb.velocity = Vector2.left * speed;
                }
                //rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Force);
                rb.velocity += Vector2.up * jumpVelocity;
                if (jumpVelocity < maxJumpVelocity)  jumpVelocity += .1f;
            }
        }
    }


    // Called whenever a collider begins colliding with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (inPlay)
        {
            if (collision.collider.tag == "Wall")
            {
                // Successfully made it to a wall
                player_sounds.WallCollide();
                isMidAir = false;
                sr.sprite = wallhang;
                if (collision.collider.name == "LeftWall")
                {
                    isFacingRight = true;
                    sr.flipX = false;
                }
                else
                {
                    isFacingRight = false;
                    sr.flipX = true;
                }
                if (rb.velocity.y > 0f)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0f);
                }
            }
        }
        if (collision.collider.tag == "Ground")
        {
            // Character "dies" and game is over
            beforeplay = false;
            player_sounds.wallSlide.Stop();
            player_sounds.Fall();
            inPlay = false;
            isWallSliding = false;
            isMidAir = false;
            sr.sprite = death;
            rb.isKinematic = true;
            rb.simulated = false;
            tr.position -= new Vector3(0, groundDeathOffset);
            tr.rotation = Quaternion.identity;
            player_pr.Stop();
            player_combo_script.numCombos = 0;
        } 
    }


    // Called whenever a collider is currently colliding with an object
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (inPlay)
        {
            if (currentTimeUntilWallSlideParticles < timeUntilWallslideParticles)
            {
                // We just stuck the landing, don't emit wallslide dust
                currentTimeUntilWallSlideParticles += Time.deltaTime;
            } else
            {
                // Emit wallslide dust from wallsliding
                if (!isWallSliding) {
                    // only play this once while sliding
                    player_sounds.wallSlide.Play();
                    if (isFacingRight) {
                        player_pr_sp.position = new Vector3(-0.35f, -0.8f, 0f);
                    } else {
                        player_pr_sp.position = new Vector3(0.35f, -0.8f, 0f);
                    }
                    isWallSliding = true;
                    player_pr.Play();
                    player_pr_em.enabled = true;
                }
            }
        }
    }

    // Called whenever a collider stops colliding with an object
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (inPlay)
        {
            // Stop emitting particles (if emitting at all), and change sprites
            currentTimeUntilWallSlideParticles = 0f;
            isWallSliding = false;
            player_pr.Stop();
            player_sounds.wallSlide.Stop();
            if (collision.collider.tag == "Wall")
            {
                sr.sprite = midair;
                isMidAir = true;
            }
        }   
    }

    public void ResetCharacter() {
        beforeplay = true;
        inPlay = false;
        isFacingRight = true;
        sr.flipX = false;
        isWallSliding = true;
        sr.sprite = wallhang;
        tr.position = new Vector3(playerStartX, playerStartY);
        tr.rotation = Quaternion.identity;
        rb.isKinematic = false;
        rb.simulated = true;
        rb.velocity = new Vector3(0f, 0f);
        isJumping = false;
        isMidAir = false;
        player_echo.enabled = false;
        jumpVelocity = minJumpVelocity;
        player_looparound.numLoops = 0;
        player_combo_script.numCombos = 0;
        spikeBumps = 0;
        currentTimeBetweenJumps = 0;
        player_combo_script.numCombos = 0;
        sg.GenerateSpikePos();
        sg.SetSpikePos();
        restartDelayCount = restartDelay;
    }
}
