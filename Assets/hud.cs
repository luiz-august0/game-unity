using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hud : MonoBehaviour
{
    public GameObject outputName;
    userData userData;

    public void Awake() {
        outputName.GetComponent<Text>().text = userData.userName;
    }
}
