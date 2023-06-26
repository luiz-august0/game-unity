using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    Cave Cave;
    UserData UserData;
    public GameObject inputName;

    void Start()
    {
        if (PlayerPrefs.HasKey("playerKey"))
        {
            string name = PlayerPrefs.GetString("playerKey");
            UserData.player = name;
            SceneManager.LoadScene("cave 1");
            Cave.totalEnemiesOnScene = 3;
            UserData.clearFields();
        }
    }

    public async void LoadScene() {
        UserData.player = inputName.GetComponent<Text>().text;

        if (UserData.player != "") {
            PlayerPrefs.SetString("playerKey", inputName.GetComponent<Text>().text);
            PlayerPrefs.Save();
            SceneManager.LoadScene("cave 1");
            Cave.totalEnemiesOnScene = 3;
            UserData.clearFields();
        }
    }
}