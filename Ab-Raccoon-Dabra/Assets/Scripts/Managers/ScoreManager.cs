using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    float currentScore;
    int totalEnemiesKilled;

    public void addToScore(int value)
    {
        currentScore += value;
    }

    public void clearScore()
    {
        currentScore = 0;
    }

    public void saveScore()
    {
        //save score to player prefs!
    }

    public void readScore()
    {
        //read score from player prefs
    }

}
