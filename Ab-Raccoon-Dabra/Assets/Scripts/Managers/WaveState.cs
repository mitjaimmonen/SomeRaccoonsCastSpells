using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveState
{
    //how many enemies to spawn
    public int totalEnemies;
    //how much extra score (if any) does the player get for beating the wave
    public int scoreBonus;
    //timer between spanws
    public float spawnTimer;
    //how long does the state last
    public float waveTimer;
    //which wave is this?
    public int waveNumber;

    public WaveState(int _enemies, int _scoreBonus, float _spawnTimer, float _waveTimer, int _waveNumber)
    {
        totalEnemies = _enemies;
        scoreBonus = _scoreBonus;
        spawnTimer = _spawnTimer;
        waveTimer = _waveTimer;
        waveNumber = _waveNumber;

    }



}
