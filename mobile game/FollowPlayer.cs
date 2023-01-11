using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    
    private GameObject player;
     Vector3 offset = new Vector3(0,1,0);
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
        
    }
}


