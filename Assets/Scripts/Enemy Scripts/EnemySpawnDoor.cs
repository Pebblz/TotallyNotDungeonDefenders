using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDoor : MonoBehaviour
{
    [SerializeField]
    GameObject LineRendererPrefab;
    [SerializeField]
    GameObject PathwayOrb;
    //this will be for if you press q to spawn next wave
    bool spawnNextWave = false;

    public GameObject[] EnemyMoveToPoints;
    public GameObject[] CurrentWaveToSpawn;
    int segementsOfWavesForLevel;
  
    //this will be for spawning the enemies in the SpawnEnemy function
    public int SpawnCount = 0;
    #region Timers
    float TimeTillNextEnemySpawn = .5f;
    float TimeTillNextBallSpawn = 0f;
    #endregion
    void Start()
    {
        CurrentWaveToSpawn = GetComponent<EnemyWave>().enemiesForThisWave;
        segementsOfWavesForLevel = GetComponent<EnemyWave>().segementsOfWavesForLevel;
        //DrawLines();
    }

    // Update is called once per frame
    void Update()
    {
        #region The Meat
        if (TimeTillNextEnemySpawn < 0 && SpawnCount < CurrentWaveToSpawn.Length - 1 && spawnNextWave == true)
        {
            SpawnEnemy();
            TimeTillNextEnemySpawn = .5f;
            SpawnCount += 1;
        }
        if (TimeTillNextBallSpawn < 0 && spawnNextWave == false)
        {
            SpawnPathOrb();
            TimeTillNextBallSpawn = 3f;
        }
        #endregion 

        #region Key Presses
        if (Input.GetKey(KeyCode.Q))
        {
            spawnNextWave = true;
        }
        #endregion

        #region Active Timers
        if (TimeTillNextEnemySpawn > -1)
        {
            TimeTillNextEnemySpawn -= Time.deltaTime;
        }
        if (TimeTillNextBallSpawn > -1)
        {
            TimeTillNextBallSpawn -= Time.deltaTime;
        }
        #endregion
    }
    void SpawnEnemy()
    {
        GameObject temp = Instantiate(CurrentWaveToSpawn[SpawnCount], this.transform.position, Quaternion.identity);
        temp.GetComponent<EnemyScript>().GoToArea = EnemyMoveToPoints;
    }
    void SpawnPathOrb()
    {
        GameObject temp = Instantiate(PathwayOrb, this.transform.position, Quaternion.identity);
        temp.GetComponent<PathWayOrbScript>().GoToArea = EnemyMoveToPoints;
    }
    public void setEnemyArray()
    {
        CurrentWaveToSpawn = GetComponent<EnemyWave>().enemiesForThisWave;
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
