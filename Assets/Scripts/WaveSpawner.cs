using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string waveName;
    //determines how many enemies spawn per wave
    public int noOfHumans;
    //determines which enemy types can spawn
    public GameObject[] typeOfHumans;
    //how long between each spawn 
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{

    public static bool playerWon;
    public Wave[] waves;
    public Transform spawnPoint;

    //we must determine which wave we are currently in
    private Wave currentWave;
    private int currentWaveNumber;
    private bool canSpawn;
    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        //set the bool for the player winning to false every time a scene changes
        playerWon = false;
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();

        //check to see if there are any more enemies left on the battlefield
        GameObject[] totalHumans = GameObject.FindGameObjectsWithTag("human");

        //scenario in which the next wave can spawn
        if(totalHumans.Length == 0 && canSpawn == false && currentWaveNumber + 1 != waves.Length)
        {
            currentWaveNumber++;
            canSpawn = true;
        }

        else if(totalHumans.Length == 0 && canSpawn == false && currentWaveNumber + 1 == waves.Length)
        {
            playerWon = true;
        }
    }

    void SpawnWave()
    {
        //if we are able to still spawn enemies
        if(canSpawn == true && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfHumans[Random.Range(0, currentWave.typeOfHumans.Length)];
            Instantiate(randomEnemy, spawnPoint.position, spawnPoint.rotation);
            currentWave.noOfHumans--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            //when no enemies are left in the current wave
            if(currentWave.noOfHumans == 0)
            {
                canSpawn = false;
            }
        }
        
    }
}
