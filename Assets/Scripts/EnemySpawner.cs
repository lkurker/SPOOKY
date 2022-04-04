using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //public gameobject that allows us to place the enemy prefabs within
    public GameObject enemyPrefab;
    private float timeBetweenWaves = 2f;

    private float countdown;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //set the countdown value to timeBetweenWaves
        countdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0)
        {
            spawnEnemy();
            countdown = timeBetweenWaves;
        }

        //we will reduce the countdown by Time.deltaTime until it reaches or becomes smaller than 0
        countdown -= Time.deltaTime;
    }

    void spawnEnemy()
    {
        //instantiate the gameobject
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
