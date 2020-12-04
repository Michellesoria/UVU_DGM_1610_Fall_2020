using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
      //enemy will find the object "player"
      enemyRb = GetComponent<Rigidbody>();
      player = GameObject.Find("Player");  
    }

    // Update is called once per frame
    void Update()
    {
      //enemy will push the player off the stage
      Vector3 lookDirection = (player.transform.position - transform.position).normalized;
      enemyRb.AddForce(lookDirection * speed);
      //if enemy goes off the scene, it is destroyed 
      if(transform.position.y < -10)
      {
        Destroy(gameObject);
      }
    }
}
