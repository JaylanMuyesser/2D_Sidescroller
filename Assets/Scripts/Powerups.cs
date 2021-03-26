using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Powerups : MonoBehaviour
{
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
    public Image timeStopBar;
    public Image timeStopFill;

    //Joke Card Variables
    public int numberOfJokeCards;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timestop();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InvinciblePowerup"))
        {
            Invincible();
            timerIsRunning = true;
            Debug.Log("touch");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("TimeStopPowerup"))
        {
            timerIsRunning = true;

            Debug.Log("touch");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Coin();
            timerIsRunning = true;
            Debug.Log("touch");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("JokeCardPowerup"))
        {
            Debug.Log("touch");
            if (numberOfJokeCards < 3)
                numberOfJokeCards++;
            timerIsRunning = true;
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
                timerIsRunning = false;
                player.invincibilityLength = 0;
                Debug.Log("Time has run out!");
                timeRemainingInvincible = 0;
                
            }
        }
    
    }
    public void Timestop()
    {      
            if (timerIsRunning)
            {
                if (timeRemainingTimeStop > 0)
                {
                timeRemainingTimeStop -= Time.deltaTime;    
                    timeStopBar.gameObject.SetActive(true);
                    timeStopFill.fillAmount = timeRemainingTimeStop;
                    Time.timeScale = 0.65f;
                }
                else
                {
                    timeStopBar.gameObject.SetActive(false);
                    Time.timeScale = 1f;
                    Debug.Log("Time has run out!");
                    timeRemainingTimeStop = 0;
                    timerIsRunning = false;
                }  
        }
    }
    public void Coin()
    {
            Debug.Log("coinnnnnns");
            score.scoreAmount += 1000;        
    }
   
   
}
