using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEffect : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
Destroy(gameObject);

Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
