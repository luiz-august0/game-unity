using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed;   // Velocidade de movimento do inimigo
    public float moveDistance;   // Distância total que o inimigo irá percorrer
    public int maxHealth = 2;   // Vida máxima do inimigo
    private int currentHealth;  // Vida atual do inimigo

    private float initialPositionX;   // Posição inicial do inimigo
    private float targetPositionX;    // Posição alvo do inimigo

    private bool movingRight = true;  // Flag para determinar a direção do movimento

    void Start()
    {
        initialPositionX = transform.position.x;
        targetPositionX = initialPositionX + moveDistance;
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Movimenta o inimigo na direção correta
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        // Verifica se o inimigo atingiu a posição alvo
        if (transform.position.x >= targetPositionX)
        {
            // Inverte a direção do movimento para esquerda
            movingRight = false;
        }
        else if (transform.position.x <= initialPositionX)
        {
            // Inverte a direção do movimento para direita
            movingRight = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            // Verifica se o inimigo ainda está vivo
            if (currentHealth > 0)
            {
                // Reduz a vida do inimigo
                currentHealth--;

                // Verifica se o inimigo foi derrotado
                if (currentHealth <= 0)
                {
                    // O inimigo foi derrotado, chame uma função para lidar com a morte do inimigo aqui
                    EnemyDeath();
                }
            }
        }
    }

    void EnemyDeath()
    {
        // Lógica para lidar com a morte do inimigo
        // Por exemplo, você pode destruir o objeto do inimigo, tocar uma animação de morte, adicionar pontos ao jogador, etc.
        Destroy(gameObject);
    }
}