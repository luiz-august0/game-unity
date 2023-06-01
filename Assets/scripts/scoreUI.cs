using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Player
{
    public string Player_Name { get; set; }
    public double Player_Score { get; set; }
}

public class ScoreUi : MonoBehaviour
{
    public RowUi rowUi;
    public ScoreManager scoreManager;

    void Start() {
        getDataScores();
    }

    public void getDataScores() {
        StartCoroutine(getRequest("https://api-gameconstruct3.vercel.app/player_score"));
    }  

    IEnumerator getRequest(string uri) {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();
        var dataJSON = JsonConvert.DeserializeObject<List<Player>>(uwr.downloadHandler.text);

        foreach (var player in dataJSON) {
            string playerName = player.Player_Name;
            double playerScore = player.Player_Score;
            scoreManager.AddScore(new Score(playerName, playerScore));
        };

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            row.player.text = scores[i].player;
            row.score.text = scores[i].score.ToString();
        };

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
    }   
}
