using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveState
{
    //how many enemies to spawn
    public float totalEnemies;
    //how many enemies have been spawned
    public float enemiesSpawned;
    //how much extra score (if any) does the player get for beating the wave
    public float scoreBonus;
    //timer between spanws
    public float spawnTimer;
    //how long does the state last
    public float waveTimer;
    //which wave is this?
    public int waveNumber;

    public WaveState(float _enemies, float _scoreBonus, float _spawnTimer, float _waveTimer, int _waveNumber)
    {
        //initializes the wave with settings from stateManager based on waveNumber

    }



}
