using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    [SerializeField] private float speedMultiplier = 25f;
    [SerializeField] private Transform enemy, respawnPoint;
    public GameObject Player;
    private PlayerScript healthCheck, invincibilityCheck;
    
    
    private Collider2D enemyCollider;
    private bool isEnemyGrounded = true;
    private Rigidbody2D enemyRB;
    [SerializeField]
    private float enemyJumpSpeed = 0.1f;

 
    void Start() {
        healthCheck = Player.GetComponent<PlayerScript>();
        invincibilityCheck = Player.GetComponent<PlayerScript>();
        enemyCollider = GetComponent<Collider2D>();
        enemyRB = GetComponent<Rigidbody2D>();

        StartCoroutine(enemyJumping());
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

        //if(collision.comparetag(ground))
        //set isEnemyGrounded to true

        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            isEnemyGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if(collision.comparetag(ground))
        //set isEnemyGrounded to false
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            isEnemyGrounded = false;
        }
        
    }


    /// <summary>
    /// This function will make enemy jump if grounded
    /// </summary>
    private IEnumerator enemyJumping()
    {
        while (true)
        {
            

            if (isEnemyGrounded)
            {
                enemyRB.AddForce(Vector2.up * enemyJumpSpeed, ForceMode2D.Impulse); // on frame it sets the velocity multiplied by enemyJumpSpeed
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}



/* Luc's notes ; making an enemy jump
First need variables to declare how high the enemy is jumping(done?)
Need a rigid body and a collider for enemy (done)
Need to make sure to check if enemy is grounded (done)
Make the enemy jump (done)
need to add force for rigid to make jump (done)
Need to make sure to  check if enemy is in the air. (yeah)
Need to make sure to enemy lands(yeah)
then set a timer (done)


  
  
*/