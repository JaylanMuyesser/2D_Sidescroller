using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    public Text scoreText, highScore;
    public float scoreAmount, pointIncreasedPerSecond;
    public GameObject Player;
    private PlayerScript healthCheck;

    void Start() {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 500f;

        healthCheck = Player.GetComponent<PlayerScript>();
    }

    void Update() {
        scoreText.text = "Score: " + (int)scoreAmount;
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;

        if (healthCheck.playerHealth ==  0) {
            pointIncreasedPerSecond = 0f;
        }
    }
}