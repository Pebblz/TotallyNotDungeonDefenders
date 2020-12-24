﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDoor : MonoBehaviour
{
    public GameObject[] EnemyMoveToPoints;
    public GameObject[] CurrentWaveToSpawn;
    int segementsOfWavesForLevel;
    float TimeTillNextSpawn = .5f;
    //this will be for spawning the enemies in the SpawnEnemy function
    public int SpawnCount = 0;
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
            TimeTillNextSpawn = .5f;
        }
        if (TimeTillNextSpawn > -1)
        {
            TimeTillNextSpawn -= Time.deltaTime;
        }
    }
    void SpawnEnemy()
    {
        GameObject temp = Instantiate(CurrentWaveToSpawn[SpawnCount], this.transform.position, Quaternion.identity);
        temp.GetComponent<EnemyScript>().GoToArea = EnemyMoveToPoints;
        SpawnCount += 1;

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
    void DrawLines()
    {
        //this func will be for letting the player know where the enemies will be 
        //moving to. it'll use the line renderer prefab
        
    }
}
