using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject outputScore;

    public void loadSceneScores() {
        SceneManager.LoadScene("menuScores");
    }

    public void loadSceneCave1() {
        SceneManager.LoadScene("cave 1");
    }

    public void Awake() {
        outputScore.GetComponent<Text>().text = UserData.scoreToShow.ToString();
    }
}
