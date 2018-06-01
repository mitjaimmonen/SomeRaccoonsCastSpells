using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    float currentScore;
    float scoreBonus = 1;
    float bonusTime;
    float maxBonus = 4;
    int totalEnemiesKilled;

    public float GetScore()
    {
        return currentScore;
    }

    public void AddToScore(int value)
    {
        currentScore += value * scoreBonus;
    }

    public void ClearScore()
    {
        currentScore = 0;
    }


    public void SaveScore()
    {
        //save score to player prefs!
    }

    public void ReadScore()
    {
        //read score from player prefs
    }

    public void KilledEnemy()
    {
        totalEnemiesKilled++;
        scoreBonus += 0.5f;
        float timeModifier = maxBonus - scoreBonus;
        bonusTime = 1+  (3 * timeModifier);
    }

    public float GetScoreBonus()
    { return scoreBonus; }
    public float GetScoreTimer()
    { return bonusTime; }

    private void Update()
    {
        if (bonusTime > 0)
        {
            bonusTime -= Time.deltaTime;
            Debug.Log("Bonus score: " + scoreBonus + ". Bonus timer: " + bonusTime);

        }
        if (bonusTime < 0)
        {
            bonusTime = 0;
            scoreBonus = 1;
        }


    }

}
