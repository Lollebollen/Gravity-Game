using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Cached variables")]
    [SerializeField] Rigidbody2D rb2D;

    [Header("Movement")]
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float deceleration;
    [SerializeField] LayerMask groundMask;
    float velocity;

    [Header("Gravity flip")]
    [SerializeField] float gravityScale;
    Vector2 gravityDirection;

    // private variables
    float playerOfset;

    private void Awake()
    {
        if (gravityScale == 0) { gravityScale = Physics2D.gravity.y; }
        gravityDirection = Vector2.up;
        playerOfset = -GetComponent<Collider2D>().bounds.extents.y;
    }

    private void Update()
    {
        Move(GroundCheck());
        Flip();
    }

    private bool GroundCheck()
    {
        Vector2 playerPos = transform.position;
        return Physics2D.Raycast(new Vector2(playerPos.x, playerPos.y + (playerOfset * gravityDirection.y)), -gravityDirection, 0.01f, groundMask);
        //Debug.DrawRay(new Vector2(playerPos.x, playerPos.y + (playerOfset * gravityDirection.y)), -gravityDirection * 0.1f, Color.red);
    }

    private void Move(bool groundCheck)
    {
        int direction = (int)Input.GetAxisRaw("Horizontal");

        if (direction != 0 && (direction < 0 == velocity > 0))
        {
            velocity *= deceleration;
        }
        else if (direction == 0 && groundCheck)
        {
            velocity *= deceleration;
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
}
