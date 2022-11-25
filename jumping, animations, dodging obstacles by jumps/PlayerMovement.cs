using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
   
    private Rigidbody playerRb;
   
    private Animator anim;
    public float jumpForce;
    public float gravity;
    public bool isOnGround = true;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem runningParticle;
    public AudioClip jumpVoice;
    public AudioClip crashVoice;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        
       playerRb = GetComponent<Rigidbody>(); 
       anim = GetComponent<Animator>();
       playerAudio = GetComponent<AudioSource>();

       Physics.gravity *= gravity;
      
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
        
       playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
       isOnGround = false;
        anim.SetTrigger("Jump_trig");
        runningParticle.Stop();
        playerAudio.PlayOneShot(jumpVoice, 5.0f);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            runningParticle.Play();
            isOnGround = true;
        }else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game over");
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            runningParticle.Stop();
            playerAudio.PlayOneShot(crashVoice, 5.0f);
        }
    }
}
