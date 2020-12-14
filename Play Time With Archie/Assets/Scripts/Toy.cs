using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour
{
    
    private GameManager gameManager;
    private float minSpeed = 7;
    private float maxSpeed = 12;
    private float xRange = 32;
    private float zSpawnPos = 18;
    public int pointValue;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        transform.position = RandomSpawnPos();
    }

     Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange,xRange), 0, zSpawnPos);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Random.Range(minSpeed, maxSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
    }
   
}
