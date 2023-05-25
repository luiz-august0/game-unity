using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class scoreData
{
    public List<scoreClass> scores;

    public scoreData() {
        scores = new List<scoreClass>();
    }
}
