using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    Cave Cave;
    UserData UserData;
    public SpriteRenderer door;
    public float moveSpeed;
    public float moveDistance;  
    public int maxHealth = 2;  
    private int currentHealth; 

    private float initialPositionX;   
    private float targetPositionX;    

    private bool movingRight = true; 
    private GameObject[] bullets;

    private Vector3 initialPosition;
    private bool isDestroyed = false;

    void Start()
    {
        initialPositionX = transform.position.x;
        targetPositionX = initialPositionX + moveDistance;
        currentHealth = maxHealth;

        initialPosition = transform.position;
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

        if (Input.GetKeyDown(KeyCode.E) && !isDestroyed)
        {
            DestroyEnemy();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("char") && collision.contacts[0].normal.y <= -1)
        {
            AudioManager.Instance.PlaySFX("Impact");
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        Cave.totalDeadEnemies = Cave.totalDeadEnemies + 1;
        UserData.score++;

        if (Cave.totalDeadEnemies == Cave.totalEnemiesOnScene) {
            door.GetComponent<SpriteRenderer>().color = Color.green;
        }

        isDestroyed = true;
        gameObject.SetActive(false);
    }
}
