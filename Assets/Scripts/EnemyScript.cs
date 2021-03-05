using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    [SerializeField] private float speedMultiplier = 25f;
    [SerializeField] private Transform enemy, respawnPoint;
    public GameObject Player;
    private PlayerScript healthCheck, invincibilityCheck;
    private Collider2D enemyCollider;

    void Start() {
        healthCheck = Player.GetComponent<PlayerScript>();
        invincibilityCheck = Player.GetComponent<PlayerScript>();
        enemyCollider = GetComponent<Collider2D>();
    }

    void Update() {
        transform.Translate(Vector2.left * Time.deltaTime * speedMultiplier);
        speedMultiplier += Time.deltaTime * 0.20f;

        if (healthCheck.playerHealth == 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Player")) {
            if (invincibilityCheck.invincibilityLength <= 0) {
                enemy.transform.position = respawnPoint.transform.position;
            }
            else
            {
                enemy.transform.position = respawnPoint.transform.position;
            }
        }
    }
}