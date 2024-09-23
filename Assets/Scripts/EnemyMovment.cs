using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    private float enemyMoveSpeed =2;
    public int x = 0;
    [SerializeField] Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {   
        while(x ==0)
        {
            x = Random.Range(-1,1);   
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (rb.velocity.x == 0)
        // {
        //     x *= -1;
        // }
        rb.velocity = new Vector2(x*enemyMoveSpeed, rb.velocity.y);

    }

    private void OnCollisionEnter2D()
    {
        x *= -1;
    }
}
