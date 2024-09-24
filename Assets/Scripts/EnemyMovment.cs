using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovment : MonoBehaviour
{
    private float enemyMoveSpeed =2;
    public int x = 0;
    [SerializeField] Rigidbody2D rb;
     SpriteRenderer spriteRenderer;

    private bool isFacingRight = true;

    private float gravity = -2;


    // Start is called before the first frame update
    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        while(x ==0)
        {
            x = Random.Range(-1,1);   
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(x*enemyMoveSpeed, gravity);

        Flip();

        
    }

    private void OnCollisionEnter2D()
    {
        x *= -1;
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
