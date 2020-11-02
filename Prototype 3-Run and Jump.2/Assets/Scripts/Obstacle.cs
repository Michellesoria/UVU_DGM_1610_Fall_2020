using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    //move obstacle left at deltatime 
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
