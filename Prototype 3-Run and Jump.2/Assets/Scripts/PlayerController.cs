using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce;
    public float gravityMod;
    public bool isGrounded = true; 
    public bool gameOver = false;
    private Animator playerAnim;
    //Particle Effects
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    //Sound Effects
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityMod;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //player will jump when spacebar is pressed, dirt particle stops, jump sound plays
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true && !gameOver)
        {
            isGrounded = false; 
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            
        
        }
    }
    void OnCollisionEnter(Collision other)
    //player is grounded dirtparticle will play
        {
            if(other.gameObject.CompareTag("Ground"))
            {
                isGrounded = true; 
                dirtParticle.Play();
            }
    //if player collides with the obstacle, game is over, crash sound plays, death animation plays, and dirt particle stops
            else if(other.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                Debug.Log("Game Over!");
                explosionParticle.Play();
                playerAudio.PlayOneShot(crashSound, 1.0f);
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                dirtParticle.Stop();
                
            }
        }
}
