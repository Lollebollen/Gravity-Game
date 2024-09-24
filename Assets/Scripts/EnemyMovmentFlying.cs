using System;
using UnityEngine;

public class EnemyMovmentFlying : MonoBehaviour
{
    int x=0;
    int y=0;
    float speed = 3;
    Vector2 velocity;
   [SerializeField] Rigidbody2D rb;

   [SerializeField] SpriteRenderer spriteRenderer;

   private bool isFacingRight = true;
    void Start()
    {
        while (x==0)
        {
            x = UnityEngine.Random.Range(-1,1);
        }
        while (y==0)
        {
            y = UnityEngine.Random.Range(-1,1);
        }
        velocity = new Vector2 (speed*x, speed*y);
        rb.velocity = velocity;
    }

    void Update()
    {
       rb.velocity = velocity;
       Flip();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = velocity.magnitude;
        Vector2 direction =  Vector2.Reflect(velocity.normalized, coll.contacts[0].normal);
       
        velocity = direction * MathF.Max(speed, 0f);
    }

    private void Flip()
    {
        if (rb.velocity.x < 0 && isFacingRight == true)
        {
            spriteRenderer.flipX = true;
            isFacingRight = !isFacingRight;
        }
        if (rb.velocity.x > 0 && isFacingRight == false)
        {    
            spriteRenderer.flipX=false;
            isFacingRight = !isFacingRight;
        }
    }

}
