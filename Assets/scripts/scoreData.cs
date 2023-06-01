using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ScoreData
{
    public List<ScoreClass> scores;

    public ScoreData() {
        scores = new List<ScoreClass>();
    }
}
