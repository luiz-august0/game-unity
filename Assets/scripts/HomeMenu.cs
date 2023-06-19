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
    public async void LoadScene() {
        UserData.player = inputName.GetComponent<Text>().text;

        if (UserData.player != "") {
            SceneManager.LoadScene("cave 1");
            Cave.totalEnemiesOnScene = 3;
        }
    }
}