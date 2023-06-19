using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadSceneScores() {
        SceneManager.LoadScene("menuScores");
    }

    public void loadSceneCave1() {
        SceneManager.LoadScene("cave 1");
    }
}
