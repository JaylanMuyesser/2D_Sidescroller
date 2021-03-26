using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject[] powerups;
    public Transform powerupSpawnPoint;
    public float timer = 10f;
    public float powerupDespawnTimer = 5f;
    public GameObject powerup;
    public bool powerupIsSpawned;
    public int powerupSpawnChance;
    // Start is called before the first frame update
    void Start()
    {
        powerupSpawnChance = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
           timer -= Time.deltaTime;
        }
        else
        {
            timer = 10f;
            powerupSpawnChance = Random.Range(1, 3);
            if(powerupSpawnChance == 2)
            {
                powerup = Instantiate(powerups[Random.Range(0, powerups.Length)], powerupSpawnPoint.position, powerupSpawnPoint.rotation);
                powerupIsSpawned = true;
            }

        }
        if (powerup != null)
        {
            powerup.transform.Translate(-0.008f, 0, 0);

        }

        if (powerupDespawnTimer > 0 && powerupIsSpawned == true)
        {
            powerupDespawnTimer -= Time.deltaTime;

        }
        else
        {
            powerupIsSpawned = false;
            powerupDespawnTimer = 5f;
            Destroy(powerup);
        }

        }
}
