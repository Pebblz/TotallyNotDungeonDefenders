using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDoor : MonoBehaviour
{
    GameObject[] EnemyMoveToPoints;
    public GameObject[] CurrentWaveToSpawn;
    int segementsOfWavesForLevel;
    float TimeTillNextSpawn = .2f;
    //this will be for spawning the enemies in the SpawnEnemy function
    int SpawnCount = 0;
    void Start()
    {
        CurrentWaveToSpawn = GetComponent<EnemyWave>().enemiesForThisWave;
        segementsOfWavesForLevel = GetComponent<EnemyWave>().segementsOfWavesForLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeTillNextSpawn < 0 && SpawnCount <= CurrentWaveToSpawn.Length)
        {
            SpawnEnemy();
        }
        if (TimeTillNextSpawn > -1)
        {
            TimeTillNextSpawn -= Time.deltaTime;
        }
    }
    void SpawnEnemy()
    {
        Instantiate(CurrentWaveToSpawn[SpawnCount], this.transform.position, Quaternion.identity);
        SpawnCount++; 
        
    }
    bool IsWaveDone()
    {
        //this isn't done yet


        //for this i'll need to check if all the monsters in the wave have been beaten
        GetComponent<EnemyWave>().ReadyForNextWave = false;
        return false;
    }
    void SpawnNextWave()
    {
        //this as stated in the name will start to spawn the next wave 
        GetComponent<EnemyWave>().currentWave += 1;
    }
}
