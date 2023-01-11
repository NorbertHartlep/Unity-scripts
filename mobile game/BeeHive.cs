using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHive : MonoBehaviour
{
    private GameObject player;
    public GameObject bee;
    public bool isDestroyingBeeHive = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Vector3.Distance(transform.position, player.transform.position) < 5 && ScoreCalculator.isDestroying == false && ScoreCalculator.beeDestroy == 0)
       {
            Debug.Log("starting to destroy bee hive");
            ScoreCalculator.isDestroying = true;
            ScoreCalculator.beeDestroy += 2;
            StartCoroutine(DestroyBeeHive());
            PlayerMovement.canMove = false;
            isDestroyingBeeHive = true;
            for(int i =0; i < 5; i++)
            {
                float x1 = transform.position.x + 5;
                float x2 = transform.position.x - 5;
                float z1 = transform.position.z + 5;
                float z2 = transform.position.z - 5;
                float xes = Random.Range(x1,x2);
                float zes = Random.Range(z1,z2);
                 Vector3 random = new Vector3(xes,1,zes);
                if(Vector3.Distance(random, player.transform.position) > 5 && Vector3.Distance(random, transform.position) < 10){
                        Instantiate(bee, random, transform.rotation);
                        
                }
            }

        } 
    }
    IEnumerator DestroyBeeHive()
    {
        //czeka 7s przed zrobieniem czegos
        yield return new WaitForSeconds(2);
        ScoreCalculator.isDestroying = false;
        ScoreCalculator.beeDestroy -= 2;
        Destroy(gameObject);
        PlayerMovement.canMove = true;
        Debug.Log("Bee Hive destroyed, enjoy your loot");
        isDestroyingBeeHive = false;
    }
}
