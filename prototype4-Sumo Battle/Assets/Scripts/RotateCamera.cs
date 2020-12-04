using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
      //Get horizontal input for camera rotation around the z-axis
      float horizontalInput = Input.GetAxis("Horizontal");
      transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
