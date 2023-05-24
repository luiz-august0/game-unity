using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class UserData  {
    public string player;
    public double score;
}

public class loadScene : MonoBehaviour
{
    private async Task SendScore() {
        String username = userData.userName;
        username = username.Replace("\"", "\\\"");;

        var user = new UserData();
        user.player = username;
        user.score = 1000;

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

    userData userData;
    public GameObject inputName;
    public async void LoadScene() {
        userData.userName = inputName.GetComponent<Text>().text;
        await SendScore();
        SceneManager.LoadScene("cave 1");
    }
}