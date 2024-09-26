using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Cached variables")]
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] Collider2D hitBox;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource audioSource;
    
    [Header("Movement")]
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float deceleration;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float maxGravitySpeed;
    float velocity;
    bool decelrate = false;

    [Header("Deathrattle")]
    [SerializeField] float deathSpin;
    [SerializeField] float deathJump;

    // private variables
    float playerOfset;
    float colliderofset;
    float gravityScale;
    Vector2 gravityDirection;

    private void Awake()
    {
        if (gravityScale == 0) { gravityScale = Physics2D.gravity.y; }
        gravityDirection = Vector2.up;
        playerOfset = -hitBox.bounds.extents.y;
        colliderofset = hitBox.offset.y;
    }

    private void Update()
    {
        Move(GroundCheck());
        FlipGRavity();
    }

    private void FixedUpdate()
    {
        if (decelrate)
        {
            Vector2 vel = rb2D.velocity;
            rb2D.velocity = new Vector2(vel.x * deceleration, vel.y);
        }
    }

    private bool GroundCheck()
    {
        Vector2 playerPos = transform.position;
        //Debug.DrawRay(new Vector2(playerPos.x, (playerPos.y + colliderofset) + (playerOfset * gravityDirection.y)), -gravityDirection * 0.1f, Color.red);
        return Physics2D.Raycast(new Vector2(playerPos.x, (playerPos.y + colliderofset) + (playerOfset * gravityDirection.y)), -gravityDirection, 0.01f, groundMask);
    }

    private void Move(bool groundCheck)
    {
        int direction = (int)Input.GetAxisRaw("Horizontal");
        velocity = rb2D.velocity.x;

        if (direction != 0 && (direction < 0 == velocity > 0))
        {
            decelrate = true;
        }
        else if (direction == 0 && groundCheck)
        {
            decelrate = true;
        }
        else
        {
            decelrate = false;
        }
        velocity += direction * acceleration * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, -maxSpeed, maxSpeed);

        rb2D.velocity = new Vector2(velocity, Mathf.Clamp(rb2D.velocity.y, -maxGravitySpeed, maxGravitySpeed));

        FlipX(direction);
    }

    private void FlipGRavity()
    {
        if (Input.GetButtonDown("Jump"))
        {
            audioSource.Play();
            gravityDirection = -gravityDirection;
            Physics2D.gravity = gravityDirection * gravityScale;
            FlipY((int)gravityDirection.y);
        }
    }

    private void FlipX(int dir)
    {
        if (dir < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (dir > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FlipY(int dir)
    {
        if (dir < 0)
        {
            spriteRenderer.flipY = true;
        }
        else if (dir > 0)
        {
            spriteRenderer.flipY = false;
        }
    }

    public void Death()
    {
        spriteRenderer.flipY = false;
        gravityDirection = Vector2.up;
        Physics2D.gravity = gravityDirection * gravityScale;
        rb2D.AddForce(gravityDirection * deathJump);
        rb2D.freezeRotation = false;
        rb2D.angularVelocity = deathSpin;
        this.enabled = false;
    }
}
