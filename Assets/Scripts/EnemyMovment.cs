
using UnityEngine;


public class EnemyMovment : MonoBehaviour
{
    private float enemyMoveSpeed =3;
    public int x = 0;
    [SerializeField] Rigidbody2D rb;
     SpriteRenderer spriteRenderer;

    private float gravity = 2;
    public bool isGroundEnemy;
    


    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isGroundEnemy)
        {
            gravity = -2;
        }
        while(x ==0)
        {
            x = Random.Range(-1,2);   
        } 
    }

    void Update()
    {

        if (rb.velocity.x < 0.1 && rb.velocity.x > -0.1)
        {
            x *= -1;
        }
        rb.velocity = new Vector2(x*enemyMoveSpeed, gravity);
        Flip(); 
    }

    // private void OnCollisionEnter2D()
    // {
    //     x *= -1;
    // }

    private void Flip()
    {
        if (rb.velocity.x < 0)
        {
           spriteRenderer.flipX = false;
        }
        if (rb.velocity.x > 0)
        {    
            spriteRenderer.flipX=true;
        }
    }
}
