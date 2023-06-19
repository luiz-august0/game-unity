using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class UserDataToSend {
    public string player;
    public double score;
}

public class EnemyBossScript : MonoBehaviour
{

    private async Task SendScore() {
        String player = UserData.player;
        player = player.Replace("\"", "\\\"");;

        var user = new UserDataToSend();
        user.player = player;
        user.score = score;

        string json = JsonUtility.ToJson(user);

        var uwr = new UnityWebRequest("https://api-gameconstruct3.vercel.app/player_score", "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        
        uwr.SendWebRequest();

        if (uwr.isNetworkError) {
            Debug.Log(uwr.error);
        } else {
            Debug.Log("Uploaded");
        }
    }

    Cave Cave;
    UserData UserData;
    public float moveSpeed;
    public float moveDistance;  
    public int maxHealth = 5;  
    private int currentHealth; 
    private double score;

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

    private async void EnemyDeath()
    {
        Destroy(gameObject);
        UserData.score++;
        score = (UserData.score * UserData.life);
        UserData.scoreToShow = score;
        await SendScore();
        SceneManager.LoadScene("gameWin");
    }
}