using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
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
}
