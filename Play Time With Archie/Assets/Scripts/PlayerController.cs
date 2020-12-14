using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 15; 
    public float xRange = 25;
    public float zRange = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player stops at given ranges to not exit the screen
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if(transform.position.z > zRange)
        {
           transform.position = new Vector3(transform.position.x, transform.position.y, zRange); 
        }
        //player moves using the left, right, up, and down arrow keys and the player faces the direction its moving

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 newPosition = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(newPosition * Time.deltaTime * speed, Space.World);
        transform.LookAt(newPosition + transform.position);
    }
}