using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    private scoreData sd;
    
    void Awake() {
        sd = new scoreData();
    }

    /*public IEnumerable<scoreClass> getHighScores() {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void addScore(scoreClass score) {
        sd.scores.Add(score);
    }*/
}
