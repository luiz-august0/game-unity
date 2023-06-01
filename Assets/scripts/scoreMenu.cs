using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{
    public ScoreUi scoreUi;

    public void reloadScoreList() {
        foreach(GameObject objclone in GameObject.FindGameObjectsWithTag("row")){
            Destroy(objclone, 2f); 
        }
        scoreUi.getDataScores();
    }

    public void loadSceneScores() {
        SceneManager.LoadScene("menuScores");
    }

    public void loadSceneMenu() {
        SceneManager.LoadScene("menu");
    }
}
