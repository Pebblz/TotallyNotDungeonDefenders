using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDoor : MonoBehaviour
{
    [SerializeField]
    GameObject LineRendererPrefab;

    //this will be for if you press q to spawn next wave
    bool spawnNextWave = false;

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
        DrawLines();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeTillNextSpawn < 0 && SpawnCount < CurrentWaveToSpawn.Length && spawnNextWave == true)
        {
            SpawnEnemy();
            TimeTillNextSpawn = .5f;
            SpawnCount += 1;
        }
        if (TimeTillNextSpawn > -1)
        {
            TimeTillNextSpawn -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            spawnNextWave = true;
        }
    }
    void SpawnEnemy()
    {
        GameObject temp = Instantiate(CurrentWaveToSpawn[SpawnCount], this.transform.position, Quaternion.identity);
        temp.GetComponent<EnemyScript>().GoToArea = EnemyMoveToPoints;
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
        GameObject temp = Instantiate(LineRendererPrefab);
        //the reason it's +1 is because it needs to start at the door than go to each of the enemie move to points
        temp.GetComponent<LineRenderer>().positionCount = EnemyMoveToPoints.Length + 1;


        temp.GetComponent<LineRenderer>().SetPosition(0,transform.position);
        for(int i = 0; i < EnemyMoveToPoints.Length; i++)
        {
            print(EnemyMoveToPoints[i].transform.position);
            temp.GetComponent<LineRenderer>().SetPosition(i + 1, EnemyMoveToPoints[i].transform.position);
        }
    }
}
