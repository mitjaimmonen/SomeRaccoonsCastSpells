using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    //how many enemies have been spawned
    public int enemiesSpawnedThisWave;
    public int enemiesKilled = 0;
    private int enemiesSpawnedOverall;
    private int batsSpawned;
    private int molesSpawned;
    public GameObject moleToSpawn;
    public GameObject batToSpawn;

    [SerializeField]
    Transform[] moleSpawnPositions;
    [SerializeField]
    Transform[] batSpawnPositions;

    public WaveState currentWave;

    [Space(10)]
    [Header("Wave modifiers")]
    [SerializeField]
    private float moleSpawnModifier = 2;
    [SerializeField]
    private float batSpawnModifier = 2;
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
        if (enemiesKilled < enemiesSpawnedOverall || enemiesSpawnedThisWave < currentWave.TotalEnemies())
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
        return currentWave.TotalEnemies() - enemiesSpawnedThisWave;
    }

    public int MolesToSpawn()
    {
        return currentWave.totalMoles - molesSpawned;
    }

    public int BatsToSpawn()
    {
        return currentWave.totalBats - batsSpawned;
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

        int moles = Mathf.RoundToInt(waveNumber * moleSpawnModifier + 5);
        int bats = Mathf.RoundToInt(waveNumber * batSpawnModifier);
        int scoreBonus = Mathf.RoundToInt(waveNumber * scoreBonusModifier + 5);
        float spawnTimer = standardSpawnTime;
        float waveTimer = standardWaveDuration + waveNumber * waveDurationModifier;

        currentWave = new WaveState(moles, bats, scoreBonus, spawnTimer, waveTimer, waveNumber);

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
                if (BatsToSpawn() > 0)
                {
                    if (MolesToSpawn() > 0)
                    {
                        int maxBatsToSpawn = Mathf.Min(BatsToSpawn(), maxEnemiesToSpawn);
                        int amountOfBats = Random.Range(1, maxBatsToSpawn);
                        SpawnBats(amountOfBats, player);
                        amountOfEnemies -= amountOfBats;
                        if (amountOfEnemies > 0)
                            SpawnMoles(amountOfEnemies, player);
                    }

                    else
                        SpawnBats(amountOfEnemies, player);
                }

                else
                    SpawnMoles(amountOfEnemies, player);
            }
        }

        else
            spawnCounter = 0;

    }

    void SpawnMoles(int value, GameObject playerPos)
    {
        for (int i = 0; i < value; i++)
        {
            int randomPosition = Random.Range(0, moleSpawnPositions.Length);
            moleToSpawn.GetComponent<Enemy>().target = playerPos.transform;
            moleToSpawn.GetComponent<Enemy>().gameBoss = GetComponent<LevelManager>();

            Instantiate(moleToSpawn, moleSpawnPositions[randomPosition].position, moleSpawnPositions[randomPosition].rotation);
            spawnCounter = 0;
            molesSpawned++;
            enemiesSpawnedThisWave++;
        }
        enemiesSpawnedOverall++;
    }

    void SpawnBats(int value, GameObject playerPos)
    {
        for (int i = 0; i < value; i++)
        {
            int randomPosition = Random.Range(0, batSpawnPositions.Length);
            batToSpawn.GetComponent<Enemy>().target = playerPos.transform;
            batToSpawn.GetComponent<Enemy>().gameBoss = GetComponent<LevelManager>();

            Instantiate(batToSpawn, batSpawnPositions[randomPosition].position, batSpawnPositions[randomPosition].rotation);
            spawnCounter = 0;
            batsSpawned++;
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

