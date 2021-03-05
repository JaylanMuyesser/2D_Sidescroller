using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    public Text healthText;
    private bool isGrounded, isJumping;
    private Rigidbody2D rb;
    public float playerHealth = 5f, jumpVelocity = 10f, jumpTimerCounter, jumpTime, invincibilityLength;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (invincibilityLength > 0) {
            invincibilityLength -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) {
            isJumping = true;
            isGrounded = false;
            jumpTimerCounter = jumpTime;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        
        if (Input.GetKey(KeyCode.Space) && isJumping == true) {
            if (jumpTimerCounter > 0) {
                rb.velocity = Vector2.up * jumpVelocity;
                jumpTimerCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            isJumping = false;
        }

        if (playerHealth == 0) {
            Destroy(gameObject);
        }

        healthText.text = "Health: " + (int)playerHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isGrounded = true;
        if (collision.collider.gameObject.CompareTag("Enemy")) {

            if (invincibilityLength <= 0) {
                playerHealth -= 1;
                invincibilityLength = 2;
            }
        }
    }
}