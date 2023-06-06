using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{
    public void reloadScoreList() {
        foreach(GameObject objclone in GameObject.FindGameObjectsWithTag("row")){
            Destroy(objclone, 0f); 
        }
        SceneManager.LoadScene("menuScores");
    }

    public void loadSceneScores() {
        SceneManager.LoadScene("menuScores");
    }

    public void loadSceneMenu() {
        SceneManager.LoadScene("menu");
    }
}
