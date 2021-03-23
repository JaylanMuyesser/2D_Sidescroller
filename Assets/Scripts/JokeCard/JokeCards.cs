using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeCards : MonoBehaviour
{
    public GameObject jokeCard;
    public Transform firePoint;
    public Powerups powerups;


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.P) && powerups.numberOfJokeCards >0)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(jokeCard, firePoint.position, firePoint.rotation);
        if (powerups.numberOfJokeCards >0)
        {
            powerups.numberOfJokeCards--;
        }
    }
}


