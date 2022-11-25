using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    public GameObject prefab;
    private Vector3 direction = new Vector3(25,0,30);
    float time = 2;
    float repeat = 2;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        InvokeRepeating("SpawnObstacle",time,repeat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle(){
        if(playerMovementScript.gameOver == false){
 Instantiate(prefab, direction, prefab.transform.rotation);
        }
    }
}
