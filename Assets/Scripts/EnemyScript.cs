using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 25f;
    public Transform enemy, respawnPoint;
    public GameObject Player;
    private PlayerScript healthCheck, invincibilityCheck;
    private Collider2D enemyCollider;

    //[SerializeField]
    //private float enemyJump; // Variable float declared for enemyJumpHeight
    [SerializeField]
    //private float enemyJumpSpeed = 2; // variable float declared for enemyJumpSpeed
    /*
    [SerializeField]
    private bool enemyGrounded;
    
    //private float enemyJumpTimer = 10;

    private Rigidbody2D enemyRb; // a Rigidbody2D being declared  for a variable
    */


    void Start()
    {
        healthCheck = Player.GetComponent<PlayerScript>();
        invincibilityCheck = Player.GetComponent<PlayerScript>();
        enemyCollider = GetComponent<Collider2D>();

        //enemyRb = enemyRb.GetComponent<Rigidbody2D>(); // making sure the variable gets the RigidBody2D component on start

       // StartCoroutine(MakeEnemyJump);
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speedMultiplier);
        speedMultiplier += Time.deltaTime * 0.20f;




        if (healthCheck.playerHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("JokeCard"))
        {
            enemy.transform.position = respawnPoint.transform.position;
        }
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            
            if (invincibilityCheck.invincibilityLength <= 0)
            {
                enemy.transform.position = respawnPoint.transform.position;
            }
            else
            {
                enemy.transform.position = respawnPoint.transform.position;
            }
        }
    }
/*    
    private IEnumerator MakeEnemyJump(0)
    {
        yield return new WaitForSeconds(enemyJumpTimer);
        enemyRb.AddForce(Vector2.up * enemyJumpSpeed, ForceMode2D.Impulse); // on frame it sets the velocity multiplied by enemyJumpSpeed
    }
 */
}
