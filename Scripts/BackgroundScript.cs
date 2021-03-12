using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform background;
    [SerializeField] private float speedMultiplier = 25f;
    [SerializeField] private float timerRespawn = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speedMultiplier);

        timerRespawn = timerRespawn - Time.deltaTime;

        if (timerRespawn <= 0)
        {
            background.transform.position = respawnPoint.transform.position;
            timerRespawn = 5f;
        }
    }
}
