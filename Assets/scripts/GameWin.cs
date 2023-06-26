using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject outputScore;
    UserData UserData;
    Cave Cave;

    public void loadSceneScores() {
        SceneManager.LoadScene("menuScores");
    }

    public void loadSceneCave1() {
        SceneManager.LoadScene("cave 1");
        Cave.totalEnemiesOnScene = 3;
        UserData.clearFields();
    }

    public void Awake() {
        outputScore.GetComponent<Text>().text = UserData.scoreToShow.ToString();
    }
}
