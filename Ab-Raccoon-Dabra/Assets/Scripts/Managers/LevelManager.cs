using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    ScoreManager scoreManager;
    StateManager stateManager;

    //event listener for enemy dying

	// Use this for initialization
	void Start () {
        scoreManager.clearScore();
        stateManager.StartWaves();
	}
	
	// Update is called once per frame
	void Update () {
        checkEnemyDeath();
        manageWaves();

	}

    void manageWaves()
    {       
        if (stateManager.currentWave.totalEnemies > stateManager.enemiesKilled /*or timer*/)
            stateManager.ExecuteWave();
        else
        {
            //adds bonus score and exits current wave
            stateManager.ExitWave();
        }
    }

   public void checkEnemyDeath()
    {
        //called by enemy OnDestroy(), adds to score and stateManager.enemiesKilled
    }
}
