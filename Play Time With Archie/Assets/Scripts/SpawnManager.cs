using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] toyPrefabs;
    private float spawnRangeX = 25f;
    private float spawnPosZ = 15f;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomToy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomToy()
    {
        int toyIndex = Random.Range(0, toyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(toyPrefabs[toyIndex], spawnPos, toyPrefabs[toyIndex].transform.rotation);
    }
}
