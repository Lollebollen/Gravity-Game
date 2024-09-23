using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float interactRange;

    Transform player;

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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
