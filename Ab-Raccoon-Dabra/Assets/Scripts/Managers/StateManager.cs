using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public float enemiesKilled;

    public GameObject enemyToSpawn;
    Transform[] spawnPositions;

    public WaveState currentWave;
    public WaveState lastWave;

    public void StartWaves()
    {
        EnterWave(0);

    }

    //the start of the wave
    public void EnterWave(int waveNumber)
    {
       //sets enemies killed and spawned to zero and takes in settings based on waveNumber
    }

    //the duration of the wave
    public void ExecuteWave()
    {
        //coroutine, while enemies spawned < totalEnemies, spawns enemies at the positions
    }

    //end of the wave
    public void ExitWave()
    {
        //coroutine? wait (if necessary) and loads next wave      
        EnterWave(currentWave.waveNumber + 1);
    }
}
