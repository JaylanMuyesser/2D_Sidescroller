using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeCardVelocity : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public Powerups powerups;



    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        EnemyScript enemy = collision.GetComponent<EnemyScript>();

        if (enemy != null)
        {


            enemy.enemy.transform.position = enemy.respawnPoint.transform.position;
            Destroy(gameObject);

        }       
    }

}



