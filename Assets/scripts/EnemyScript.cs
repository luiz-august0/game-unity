using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Cave Cave;
    public SpriteRenderer door;
    public float moveSpeed;
    public float moveDistance;  
    public int maxHealth = 2;  
    private int currentHealth; 

    private float initialPositionX;   
    private float targetPositionX;    

    private bool movingRight = true; 
    private GameObject[] bullets;

    void Start()
    {
        initialPositionX = transform.position.x;
        targetPositionX = initialPositionX + moveDistance;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x >= targetPositionX)
        {
            movingRight = false;
        }
        else if (transform.position.x <= initialPositionX)
        {
            movingRight = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            bullets = GameObject.FindGameObjectsWithTag("bullet");

            for (int i = 0; i <= bullets.Length - 1; i++) {
                Destroy(bullets[i]);
            }

            AudioManager.Instance.PlaySFX("Impact");

            if (currentHealth > 0)
            {
                currentHealth--;

                if (currentHealth <= 0)
                {
                    EnemyDeath();
                }
            }
        }
    }

    void EnemyDeath()
    {
        Destroy(gameObject);
        Cave.totalDeadEnemies = Cave.totalDeadEnemies + 1;

        if (Cave.totalDeadEnemies == Cave.totalEnemiesOnScene) {
            door.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}