using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Cached variables")]
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] Collider2D hitBox;
    
    [Header("Movement")]
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float deceleration;
    [SerializeField] LayerMask groundMask;
    float velocity;

    [Header("Deathrattle")]
    [SerializeField] float deathSpin;
    [SerializeField] float deathJump;

    // private variables
    float playerOfset;
    float gravityScale;
    Vector2 gravityDirection;

    private void Awake()
    {
        if (gravityScale == 0) { gravityScale = Physics2D.gravity.y; }
        gravityDirection = Vector2.up;
        playerOfset = -hitBox.bounds.extents.y;
    }

    private void Update()
    {
        Move(GroundCheck());
        Flip();
    }

    private bool GroundCheck()
    {
        Vector2 playerPos = transform.position;
        //Debug.DrawRay(new Vector2(playerPos.x, playerPos.y + (playerOfset * gravityDirection.y)), -gravityDirection * 0.1f, Color.red);
        return Physics2D.Raycast(new Vector2(playerPos.x, playerPos.y + (playerOfset * gravityDirection.y)), -gravityDirection, 0.01f, groundMask);
    }

    private void Move(bool groundCheck)
    {
        int direction = (int)Input.GetAxisRaw("Horizontal");
        velocity = rb2D.velocity.x;
        // dir = -1 true
        // dir  = 1 false

        //velocity = -1 false
        //Velocity = 1 true


        if (direction != 0 && (direction < 0 == velocity > 0))
        {
            velocity *= deceleration;
            Debug.Log("First");
        }
        else if (direction == 0 && groundCheck)
        {
            velocity *= deceleration;
            Debug.Log("Secound");
        }
        velocity += direction * acceleration * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, -maxSpeed, maxSpeed);

        rb2D.velocity = new Vector2(velocity, rb2D.velocity.y);
    }

    private void Flip()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gravityDirection = -gravityDirection;
            Physics2D.gravity = gravityDirection * gravityScale;
        }
    }

    public void Death()
    {
        rb2D.AddForce(gravityDirection * deathJump);
        rb2D.freezeRotation = false;
        rb2D.angularVelocity = deathSpin;
        this.enabled = false;
    }
}
