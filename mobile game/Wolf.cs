using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private Rigidbody quickEnemyRb;
    private GameObject target;
    private float speed = 6.0f;
    // Start is called before the first frame update
    //zobacz jumping
    void Start()
    {
        quickEnemyRb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(transform.position.y < 0){
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
        }
         transform.LookAt(target.transform.position);
    }
     private void OnTriggerEnter(Collider other)
    {
        
    }
}
