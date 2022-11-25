using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] dogPrefabs;
    private float Xes = 20.0f;
    private float Zes = 20.0f;
    private float start = 2.0f;
    private float cd = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("SpawnRandomAnimal", start, cd);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {


             int animalIndex = Random.Range(0, dogPrefabs.Length);
             
             Vector3 spawn = new Vector3(Random.Range(-Xes, Xes) , 0 , Zes);
             
                Instantiate(dogPrefabs[animalIndex], spawn, dogPrefabs[animalIndex].transform.rotation);
    }
}
