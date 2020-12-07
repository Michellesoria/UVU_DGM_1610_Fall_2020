using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] toyPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int toyIndex = Random.Range(0, toyPrefabs.Length);
        Instantiate(toyPrefabs[toyIndex], new Vector3(0, 0, 13), toyPrefabs[toyIndex].transform.rotation);
    }
}
