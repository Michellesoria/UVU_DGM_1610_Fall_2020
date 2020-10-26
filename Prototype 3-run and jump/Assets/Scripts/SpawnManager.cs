using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePreb;
    private Vector3 spawnPos = new Vector3 (25, 0, 0);
    private float startDelay;
    private float repeatDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatDelay);
    }

    //spawn obstacle 
    void SpawnObstacles()
    {
        Instantiate(obstaclePreb, spawnPos, obstaclePreb.transform.rotation);
    }
}
