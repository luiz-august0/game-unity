using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class scoreClass
{
    public string player;
    public float score;

    public scoreClass(string player, float score) {
        this.player = player;
        this.score = score;
    }
}
