using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class scoreMenu : MonoBehaviour
{
    public void getDataScores() {
        StartCoroutine(getRequest("https://api-gameconstruct3.vercel.app/player_score"));
    }  

    public void loadSceneScores() {
        SceneManager.LoadScene("menuScores");
    }

    public void loadSceneMenu() {
        SceneManager.LoadScene("menu");
    }

    IEnumerator getRequest(string uri) {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }   
}
