using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float interactRange;
    [SerializeField] Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    int curretSprite = 0;

    Transform player;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void Update()
    {
        Interact();   
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        { 
            if (player == null)
            {
                player = FindAnyObjectByType<PlayerMovement>().transform;
            }
            if (Vector2.SqrMagnitude(player.position - transform.position) < interactRange * interactRange)
            {
                FlopSwitch();
            }
        }

    }

    private void FlopSwitch()
    {
        if (door == null) { return; }
        door.SetActive(!door.activeSelf);
        int length = sprites.Length;
        if (length > 0)
        {
            if (curretSprite + 1 >= length) { curretSprite = 0; }
            else { curretSprite++; }
            spriteRenderer.sprite = sprites[curretSprite];
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
