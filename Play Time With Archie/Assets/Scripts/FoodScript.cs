using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private float lowerBound = -11;
    private float spawnRangeX = 25f;
    private float spawnPosZ = 15f;
    private float minSpeed = 7;
    private float maxSpeed = 12;


     // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Random.Range(minSpeed, maxSpeed));
        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameManager.health += 1;
        Destroy(gameObject);
    }

    void SpawnRandomPos()
    { 
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(gameObject, spawnPos, gameObject.transform.rotation);
    }
}
