using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private Rigidbody basicEnemyRb;
    private GameObject target;
    private float speed = 2.50f;
    // Start is called before the first frame update
    //zobacz jumping
    void Start()
    {
        basicEnemyRb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * Vector3.forward * speed);

        if(transform.position.y < 0){
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
        }
         transform.LookAt(target.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
        
        
    }
    //ontriggerenter do triggerow a oncollisionenter do kolizji

