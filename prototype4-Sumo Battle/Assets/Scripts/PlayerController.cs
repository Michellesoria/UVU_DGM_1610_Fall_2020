using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float powerUpStr = 15.0f;
    public bool hasPowerUp;
    public GameObject focalPoint;
    public GameObject powerupIndicator;
    private Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
      playerRb = GetComponent<Rigidbody>();
      focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
      //player moves forward or back using up and down arrow keys
      float forwardInput = Input.GetAxis("Vertical");
      playerRb.AddForce(focalPoint.transform.forward * forwardInput * Time.deltaTime * speed); 
      powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f,0);
    }

    //if player collides with the powerup, power up is destroyed and it set to active
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("PowerUp"))
        {
          //when player collides with powerup, object is destroyed and 7 sec countdown starts
          hasPowerUp = true;
          Debug.Log("PowerUp = " + hasPowerUp);
          Destroy(collider.gameObject);
          StartCoroutine(PowerUpCountDown());
          powerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
          //gathering the rigidbody of the enemy
          Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
          //enemy's position is made different from the player's 
          Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
          Debug.Log("Player collided with " + collision.gameObject + " with powerup set to " + hasPowerUp);
          //pushing the enemy away from the player 
          enemyRigidbody.AddForce(awayFromPlayer * powerUpStr, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDown()
    {
      //countdown of 7 seconds, after 7 seconds powerup is gone
      yield return new WaitForSeconds(7); 
      hasPowerUp = false;
      powerupIndicator.gameObject.SetActive(false);
    }
}
