using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform background;
    [SerializeField] private float speedMultiplier = 25f;
    [SerializeField] private float timerRespawn = 0f;

    public GameObject Player;
    private PlayerScript healthCheck;

    private void Start()
    {
        healthCheck = Player.GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (healthCheck.playerHealth > 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speedMultiplier);
            timerRespawn = timerRespawn - Time.deltaTime;
        }
        else
        {
            timerRespawn = 1f;
        }    

        if (timerRespawn <= 0)
        {
            background.transform.position = respawnPoint.transform.position;
            timerRespawn = 5f;
        }
    }
}
