﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 10;
    public int enemyCount; 
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
      SpawnEnemyWave(waveNumber);
      Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    void Update()
    {
      //counts number of enemies on the scene 
      enemyCount = FindObjectsOfType<Enemy>().Length; 
      //keeps spawning enemies 
      if(enemyCount == 0)
      {
        waveNumber ++;
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
      }
    }

    private Vector3 GenerateSpawnPosition()
    {
      //spanws enemies at random place on scene 
      float spawnPosX = Random.Range(-spawnRange, spawnRange);
      float spawnPosZ = Random.Range(-spawnRange, spawnRange);
      Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
      return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
      int i;
      for(i = 0; i  < enemiesToSpawn; i++)
      {
        //spawns enemies to the scene
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
      }
    }
}
