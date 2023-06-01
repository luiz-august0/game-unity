using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Score
{
    public string player;
    public double score;

    public Score(string player, double score) {
        this.player = player;
        this.score = score;
    }
}
