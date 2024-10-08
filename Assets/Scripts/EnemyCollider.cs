using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

    [SerializeField] Collider2D enemyCollider;
    [SerializeField] AudioSource hitSource;

    GameMenu gameMenu;

    private void Awake()
    {
        gameMenu = FindAnyObjectByType<GameMenu>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            hitSource.Play();
            GameObject player = other.gameObject; //GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().Death();

            if (gameMenu == null) { return; }
            gameMenu.GameOverMessage();
        }
    }
}
