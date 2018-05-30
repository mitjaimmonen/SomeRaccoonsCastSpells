using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    //how many enemies have been spawned
    public int enemiesSpawnedThisWave;
    public int enemiesKilled = 0;
    public int enemiesSpawnedOverall;
    public GameObject objectToSpawn;
    [SerializeField]
    Transform[] spawnPositions;

    public WaveState currentWave;

    [Space(10)]
    [Header("Wave modifiers")]
    [SerializeField]
    private float enemySpawnModifier = 2;
    [SerializeField]
    private float scoreBonusModifier = 5;
    [SerializeField]
    private float standardSpawnTime = 1;
    [SerializeField]
    private float standardWaveDuration = 10;
    [SerializeField]
    private float waveDurationModifier = 1;
    [SerializeField]
    private int maxEnemiesPerSpawn = 3;

    private float spawnCounter = 0;
    private float timerCounter = 0;

    public bool EnemiesLeft()
    {
        if (enemiesKilled < enemiesSpawnedOverall || enemiesSpawnedThisWave < currentWave.totalEnemies)
            return true;
        else
            return false;
    }

    public bool WithinTimer()
    {
        //checks if there is still time before next wave
        if (timerCounter < currentWave.waveTimer)
            return true;
        else
            return false;

    }

    public float TimerForDisplay()
    {
        return currentWave.waveTimer - timerCounter;
    }

    public int EnemiesToSpawn()
    {
        return currentWave.totalEnemies - enemiesSpawnedThisWave;
    }

    public void StartWaves()
    {
        EnterWave(0);

    }

    //the start of the wave
    public void EnterWave(int waveNumber)
    {
        //sets enemies killed and spawned to zero and takes in settings based on waveNumber
        enemiesKilled = 0;
        enemiesSpawnedThisWave = 0;
        timerCounter = 0;

        int enemies = Mathf.RoundToInt(waveNumber * enemySpawnModifier + 5);
        int scoreBonus = Mathf.RoundToInt(waveNumber * scoreBonusModifier + 5);
        float spawnTimer = standardSpawnTime;
        float waveTimer = standardWaveDuration + waveNumber * waveDurationModifier;

        currentWave = new WaveState(enemies, scoreBonus, spawnTimer, waveTimer, waveNumber);

        if (currentWave != null)
        {
            Debug.Log("Entered wave " + waveNumber);
        }

    }

    //the duration of the wave
    public void ExecuteWave(GameObject player)
    {
        timerCounter += Time.deltaTime;

        if (EnemiesToSpawn() > 0)
        {   // while enemies spawned < totalEnemies, spawns enemies at the 
            spawnCounter += Time.deltaTime;
            if (spawnCounter >= currentWave.spawnTimer)
            {
                int maxEnemiesToSpawn = Mathf.Min(EnemiesToSpawn(), maxEnemiesPerSpawn);
                int amountOfEnemies = Random.Range(1, maxEnemiesToSpawn);
                SpawnEnemies(amountOfEnemies, player);
            }
        }

        else
            spawnCounter = 0;

    }

    void SpawnEnemies(int value, GameObject playerPos)
    {
        for (int i = 0; i < value; i++)
        {
            int randomPosition = Random.Range(0, spawnPositions.Length);
            objectToSpawn.GetComponent<Enemy>().target = playerPos.transform;
            objectToSpawn.GetComponent<Enemy>().gameBoss = GetComponent<LevelManager>();

            Instantiate(objectToSpawn, spawnPositions[randomPosition].position, spawnPositions[randomPosition].rotation);
            spawnCounter = 0;
            enemiesSpawnedThisWave++;
        }
        enemiesSpawnedOverall++;
    }


    //end of the wave
    public void ExitWave()
    {
        //coroutine? wait (if necessary) and loads next wave   
        int nextWave = currentWave.waveNumber + 1;
        Debug.Log("Next wave is" + nextWave);
        EnterWave(currentWave.waveNumber + 1);
    }
}

