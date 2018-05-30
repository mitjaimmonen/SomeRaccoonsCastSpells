using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveState
{
    //how many enemies to spawn
    public int totalMoles;
    //how much extra score (if any) does the player get for beating the wave
    public int scoreBonus;
    //timer between spanws
    public float spawnTimer;
    //how long does the state last
    public float waveTimer;
    //which wave is this?
    public int waveNumber;
    //how many bats?
    public int totalBats;

    public int TotalEnemies ()
    {
        return totalMoles + totalBats;
    }

    public WaveState(int _moles, int _bats, int _scoreBonus, float _spawnTimer, float _waveTimer, int _waveNumber)
    {
        totalMoles = _moles;
        totalBats = _bats;
        scoreBonus = _scoreBonus;
        spawnTimer = _spawnTimer;
        waveTimer = _waveTimer;
        waveNumber = _waveNumber;

    }



}
