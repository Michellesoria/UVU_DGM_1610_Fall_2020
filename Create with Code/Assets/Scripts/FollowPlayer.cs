using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Sets the target for the camera to follow
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -10);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the main camera follow the players position
     transform.position = player.transform.position + offset;
    }
}
