using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWallBlocker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bee") || other.CompareTag("Bear") || other.CompareTag("Wolf") || other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
