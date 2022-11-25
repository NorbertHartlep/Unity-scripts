using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {       
                                                                    
     Vector3 direction = (player.transform.position - transform.position).normalized;
       enemyRb.AddForce( direction  * speed); 
       if(transform.position.y < -10)
       {
        Destroy(gameObject);
       }

       
    }
}
