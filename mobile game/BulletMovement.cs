using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    private Rigidbody bulletRb;
    private float speed = 20.0f;
    private GameObject player;
    private Vector3 playerPos;
  
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerPos = player.transform.forward;
    }
    // Update is called once per frame
    void Update()
    {
       transform.Translate(playerPos * speed * Time.deltaTime);
       
        //deleting bullets when they reach bad values
        if(transform.position.z < -300 || transform.position.z > 300 || transform.position.x > 300 || transform.position.x < -300){
                Destroy(gameObject);
        }
        //if bullet falling off set y to 0
        if(transform.position.y < 1){
            transform.position = new Vector3(transform.position.x,1,transform.position.z);
        }

    }

    void OnTriggerEnter(Collider other){

        //if collides destroy enemy and itself WITHOUT havepowerup
        if(other.tag == "Bee"){
            Destroy(gameObject);
            Destroy(other.gameObject);
           ScoreCalculator.AddToScore(1);
           Debug.Log(ScoreCalculator.score);
        }
        else if(other.tag == "Wolf"){
            Destroy(gameObject);
            Destroy(other.gameObject);
           ScoreCalculator.AddToScore(3);
           Debug.Log(ScoreCalculator.score);
        }
        else if(other.tag == "Bear"){
            Destroy(gameObject);
            Destroy(other.gameObject);
         ScoreCalculator.AddToScore(2);
         Debug.Log(ScoreCalculator.score);
        }
    }
    
}
