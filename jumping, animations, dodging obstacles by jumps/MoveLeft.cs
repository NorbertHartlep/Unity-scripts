using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    
    private PlayerMovement playerControllerScript;
    public float speed = 30.0f;
    // Start is called before the first frame update
    private float leftBound = -25;
    void Start()
    {
       
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(playerControllerScript.gameOver == false)
        {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
       
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
                Destroy(gameObject);
        }
        
    }
}
