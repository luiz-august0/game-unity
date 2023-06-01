using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public GameObject outputName;
    UserData UserData;

    public void Awake() {
        outputName.GetComponent<Text>().text = UserData.player;
    }
}
