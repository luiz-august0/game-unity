using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public GameObject outputName;
    public GameObject outputLife;
    UserData UserData;

    public void Update() {
        outputName.GetComponent<Text>().text = UserData.player;
        outputLife.GetComponent<Text>().text = UserData.life.ToString();
    }
}
