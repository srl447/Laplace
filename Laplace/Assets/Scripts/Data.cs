﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data 
{
    //This stores all the data needed for saving
    public int sceneNumber;
    public int progressIndex;
    public string opponentName;
    public int score;

    public Data(GameManager game)
    {
        sceneNumber = game.GetSceneNumber();
        progressIndex = game.progress;
        opponentName = game.opponent;
        score = game.score;
    }
}
