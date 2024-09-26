using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pods : MonoBehaviour
{
    [SerializeField, Tooltip("To player center point")] float interactRange;
    
    Transform player;
    GameMenu gameMenu;
    AudioSource AudioSource;

    bool over = false;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
        gameMenu = FindAnyObjectByType<GameMenu>();
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!over)
        {
            Interact();
        }
    }

    private void Interact()
    {
        if (player == null)
        {
            Debug.Log("Player not found");
            return;
        }
        if (Vector2.SqrMagnitude(player.position - transform.position) < interactRange * interactRange)
        {
            if (gameMenu == null)
            {
                Debug.Log("GameMenu not found");
                return;
            }
            over = true;
            AudioSource.Play();
            gameMenu.Win();
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
