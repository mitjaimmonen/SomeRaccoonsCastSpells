using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public ScoreManager scoreManager;
    public StateManager stateManager;

    public GameObject player;

    //event listener for enemy dying should be here maybe????

    public float TimerForDisplay()
    {
        return stateManager.TimerForDisplay() + 1;
    }

    public float ScoreForDisplay()
    {
        return scoreManager.GetScore();
    }

    public int WaveNumberForScore()
    {
        return stateManager.currentWave.waveNumber;
    }


    private void Awake()
    {
        stateManager.StartWaves();
    }
    void Start()
    {
        scoreManager.ClearScore();
    }

    void Update()
    {
        ManageWaves();

    }

    void ManageWaves()
    {
        if (stateManager.EnemiesLeft() && stateManager.WithinTimer())
            stateManager.ExecuteWave(player);
        else
        {
            //adds bonus score and exits current wave
            stateManager.ExitWave();
        }
    }

    public void EnemyDeath(int scoreValue)
    {
        //called by enemy OnDestroy(), adds to score and stateManager.enemiesKilled
        scoreManager.AddToScore(scoreValue);
        scoreManager.KilledEnemy();
        stateManager.enemiesKilled++;

    }

}
