using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour {
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter2D(Collider2D other) {
        enemy.transform.position = respawnPoint.transform.position;
    }
}