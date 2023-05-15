using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    userData userData;
    public GameObject inputName;
    public void LoadScene() {
        userData.userName = inputName.GetComponent<Text>().text;
        SceneManager.LoadScene("game");
    }
}
