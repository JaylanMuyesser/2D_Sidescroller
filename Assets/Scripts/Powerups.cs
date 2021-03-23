using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public bool invincibleActive = false;

    public PlayerScript player;
    public ScoreScript score;
    [SerializeField]
    private bool timerIsRunning = false;
    [SerializeField]
    private float timeRemainingInvincible = 10;
    [SerializeField]
    private float timeRemainingTimeStop = 5;
    [SerializeField]
    //private float timeRemainingCoin = 5;

    //Joke Card Variables
    public int numberOfJokeCards;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleActive)
        {
            Invincible();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.gameObject.CompareTag("InvinciblePowerup"))
        {      
            timerIsRunning = true;
            Debug.Log("touch");
            invincibleActive = true;
            Destroy(collision.gameObject);
        }





    }
    public void Invincible()
    {
        if (timerIsRunning)
        {
            if (timeRemainingInvincible > 0)
            {
                player.invincibilityLength = 100;
                timeRemainingInvincible -= Time.deltaTime;
            }
            else
            {
                player.invincibilityLength = 0;
                Debug.Log("Time has run out!");
                timeRemainingInvincible = 0;
                timerIsRunning = false;
            }
        }
    
    }
    public void Timestop()
    {
        if (gameObject.CompareTag("TimeStopPowerup"))
        {
            if (timerIsRunning)
            {
                if (timeRemainingTimeStop > 0)
                {
                    Time.timeScale = 0.65f;
                    timeRemainingTimeStop -= Time.deltaTime;
                }
                else
                {
                    Time.timeScale = 1f;
                    Debug.Log("Time has run out!");
                    timeRemainingTimeStop = 0;
                    timerIsRunning = false;
                }
            }
        }
    }
    public void Coin()
    {
        if (gameObject.CompareTag("Coin"))
        {
            score.scoreAmount += 1000;
        }
    }
    public void JokeCard()
    {
        if (gameObject.CompareTag("Joke Card"))
        {
            if (numberOfJokeCards <= 10)
                numberOfJokeCards++;         
        }
    }

}
