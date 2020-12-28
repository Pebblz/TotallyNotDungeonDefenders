using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public int currentWave = 1;
    //This is for the amount of segements of enemies in the waves
    public int segementsOfWavesForLevel;
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

    //this'll be for knowing when the next wave is ready to spawn 
    public bool ReadyForNextWave = false;

    void Start()
    {
        AddMonstersToArray();
        //when you mix up the array it'll break it up into
        //1 segement that'll be repeatabley spawned to the number of segementsOfWavesForLevel
        MixUpArray();
        PrevWave = currentWave;
        ReadyForNextWave = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this will empty the prev wave of enemies then add the next
        //wave of monsters into the array 
        if (PrevWave != currentWave && ReadyForNextWave == false)
        {
            EmptyArray();
            AddMonstersToArray();
            MixUpArray();
            PrevWave = currentWave;
            ReadyForNextWave = true;
        }
    }

    void MixUpArray()
    {
        //this'll be for randomizing this waves array
        int tempnum = 0;
        int tempnum2 = 0;
        GameObject[] temp1 = new GameObject[500];
        GameObject[] temp2 = new GameObject[500];
        
        for (int i = 0; i < enemiesForThisWave.Length; i++)
        {
            if (temp1[i] == null)
            {
                if (enemiesForThisWave[i] != null)
                {
                    if (enemiesForThisWave[i].GetComponent<EnemyWeight>().ThisEnemiesWeight == EnemyWeight.EnemyWeights.Small)
                    {
                        temp1[i] = enemiesForThisWave[i];
                        tempnum++;
                    }
                }
            }

            if (temp2[i] == null)
            {
                if (enemiesForThisWave[i] != null)
                {
                    if (enemiesForThisWave[i].GetComponent<EnemyWeight>().ThisEnemiesWeight != EnemyWeight.EnemyWeights.Small)
                    {
                        temp2[tempnum2] = enemiesForThisWave[i];
                        tempnum2++;
                    }
                }
            }
            if(i >= enemiesForThisWave.Length - 1)
            {

                //this will resize the array to however many enemies are inside of it 
                Array.Resize(ref temp1, tempnum);
                //this will resize the array to however many enemies are inside of it 
                Array.Resize(ref temp2, tempnum2);
            }
        }
        //once it gets all the units it'll need to spawn it
        // empties the array so it can be refilled 
        EmptyArray();

        //this'll get the percent of units in the array we should spawn
        float Percent = 100 / segementsOfWavesForLevel;
        Percent = Percent * .01f;
        float num1 = temp1.Length * Percent;
        Mathf.Round(num1);

        float num2 = temp2.Length * Percent;
        Mathf.Round(num2);
        int anotherTempNumber = 0;
        int anotherTempNumber2 = 0;

        for (int i = 0; i < temp1.Length + temp2.Length; i++)
        {
            if (anotherTempNumber <= num1)
            {
                
                enemiesForThisWave[i] = temp1[anotherTempNumber];
                anotherTempNumber++;
            }
            if (anotherTempNumber > num1)
            {
                if (anotherTempNumber2 < num2)
                {
                    enemiesForThisWave[i] = temp2[anotherTempNumber2];
                    anotherTempNumber2++;
                }
            }
        }
         
    }
    //this adds monsters for the current wave to the array 
    void AddMonstersToArray()
    {
        for (int i = 0; i < enemytype1[currentWave]; i++)
        {
            enemiesForThisWave[i] = EnemyTypesArray[0];
        }
        for (int i = 0; i < enemytype2[currentWave]; i++)
        {
            enemiesForThisWave[i + enemytype1[currentWave]] = EnemyTypesArray[1];
        }
    }
    //This just as the name implies, empties the array
    void EmptyArray()
    {
        Array.Clear(enemiesForThisWave, 0, enemiesForThisWave.Length);
    }
}
