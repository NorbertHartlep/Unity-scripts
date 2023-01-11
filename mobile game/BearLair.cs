using System.Threading;
//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearLair : MonoBehaviour
{
    private GameObject player;
    public GameObject bear;
    public bool isDestroyingBearLair = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Vector3.Distance(transform.position, player.transform.position) < 5 && ScoreCalculator.isDestroying == false && ScoreCalculator.bearDestroy == 0)
       {
            Debug.Log("starting to destroy bear lair");
            ScoreCalculator.isDestroying = true;
            ScoreCalculator.bearDestroy += 10;
            StartCoroutine(DestroyBearLair());
            PlayerMovement.canMove = false;
            isDestroyingBearLair = true;
            for(int i = 0; i < 10; i++)
            {
                //opoznij wykonywanie fora potem ustaw zmniejszenie predkosci zamiast unieruchomienia
                float x1 = transform.position.x + 5;
                float x2 = transform.position.x - 5;
                float z1 = transform.position.z + 5;
                float z2 = transform.position.z - 5;
                float xes = Random.Range(x1,x2);
                float zes = Random.Range(z1,z2);
                 Vector3 random = new Vector3(xes,1,zes);
                if(Vector3.Distance(random, player.transform.position) > 5 && Vector3.Distance(random, transform.position) < 10){
                        Instantiate(bear, random, transform.rotation);
                        
                }
            }
        } 
    }
    IEnumerator DestroyBearLair()
    {
        //czeka 7s przed zrobieniem czegos
        yield return new WaitForSeconds(10);
        ScoreCalculator.isDestroying = false;
        ScoreCalculator.bearDestroy -= 10;
        Destroy(gameObject);
        Debug.Log("Bear Lair destroyed, enjoy your loot");
        PlayerMovement.canMove = true;
        isDestroyingBearLair = false;
    }
    
}
