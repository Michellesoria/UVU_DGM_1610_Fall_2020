using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePreb;
    private Vector3 spawnPos = new Vector3 (25, 0, 0);
    private float startDelay = 1.5f;
    private float repeatDelay = 1.5f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    //If game over is false, continue to instantiate obstacles
    void SpawnObstacles()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePreb, spawnPos, obstaclePreb.transform.rotation);
        }
    }
}