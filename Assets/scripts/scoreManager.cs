using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    
    void Awake() {
        sd = new ScoreData();
    }

    /*public IEnumerable<ScoreClass> getHighScores() {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void addScore(ScoreClass score) {
        sd.scores.Add(score);
    }*/
}
