using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDoor : MonoBehaviour
{
    GameObject[] EnemyMoveToPoints;
    public GameObject[] CurrentWaveToSpawn;
    float TimeTillNextSpawn = .1f;

    void Start()
    {
        CurrentWaveToSpawn = GetComponent<EnemyWave>().enemiesForThisWave;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
