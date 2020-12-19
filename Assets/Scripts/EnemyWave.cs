using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public int currentWave = 1;
    int PrevWave;
    public int LastWaveForLevel;
    //this will be for each diffrent type of enemy
    public GameObject[] EnemyTypesArray;
    //the index of these arrays are the wave they'll spawn at
    //the number at the index is the amount will spawn in that wave
    //i'll rename the array / add more when we have enemies to spawn
    public int[] enemytype1;
    public int[] enemytype2;
    //this'll be for what's going to spawn this wave
    public GameObject[] enemiesForThisWave = new GameObject[500];

    private static System.Random rng = new System.Random();
    void Start()
    {
        AddMonstersToArray(enemiesForThisWave);
        PrevWave = currentWave;
    }

    // Update is called once per frame
    void Update()
    {
        //this will empty the prev wave of enemies then add the next
        //wave of monsters into the array 
        if (PrevWave != currentWave)
        {
            EmptyArray(enemiesForThisWave);
            AddMonstersToArray(enemiesForThisWave);
            PrevWave = currentWave;
        }
    }

    void MixUpArray(GameObject[] TempArray)
    {
        //this'll be for randomizing this waves array

    }
    //this adds monsters for the current wave to the array 
    void AddMonstersToArray(GameObject[] TempArray)
    {
        for (int i = 0; i < enemytype1[currentWave]; i++)
        {
            enemiesForThisWave[i] = EnemyTypesArray[0];
        }
        for(int i = 0; i < enemytype2[currentWave]; i++)
        {
            enemiesForThisWave[i + enemytype1[currentWave]] = EnemyTypesArray[1];
        }
    }
    //This just as the name implies, empties the array
    void EmptyArray(GameObject[] TempArray)
    {
        Array.Clear(TempArray, 0, TempArray.Length);
    }
}
