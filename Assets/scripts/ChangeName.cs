using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeName : MonoBehaviour
{
    UserData UserData;

    public void goToMenu() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        UserData.clearFields();
        SceneManager.LoadScene("menu");
    }
}
