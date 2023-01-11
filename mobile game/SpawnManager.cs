using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyLairPrefabs;
        GameObject[] en1;
        GameObject[] en2;
        GameObject[] en3;

//1 bear 2 bee 3 wolf
    public static GameObject[]enemyPrefabs;
    private float spawnRate = 4.0f;
    private float Xes = 280.0f;
    private float Zes = 280.0f;
    // Start is called before the first frame update
    void Start()
    //todo zrob fora ktory aktywuje sie przy isdestroying i ma liczbe powtorzen zalezna od typu legowiska ktore niszczymy
    //w forze zrob losowy wektor opierajacy sie na pozycji legowiska
    // jesli dystans tego wektora od gracza bedzie wiekszy niz 5 a jednoczesnie mniejszy niz 10 od legowiska to zespawnuj moba
    // w przeciwnym wypadku kontynuuj, nie dodawaj powtorzen a przynajmniej nie duzo, pozwoli to na randomowe spawnowanie mobow
    //uzyj thread.sleep zeby opoznic kolejne wykonania petli
    {
        en1 = GameObject.FindGameObjectsWithTag("BeeHive");
        en2 = GameObject.FindGameObjectsWithTag("BearLair");
        en3 = GameObject.FindGameObjectsWithTag("WolfLair");
        InvokeRepeating("spawnPrefab", 2.0f, spawnRate);
        
    }
    //spawn enemy lair script
    void spawnPrefab(){
        //spawning enemy lair in random y rotation and random position
        var randomRotation = Quaternion.Euler(0 ,Random.Range(0, 360), 0);
        int enemyIndex = Random.Range(0, enemyLairPrefabs.Length);
        var spawnPrefab = Instantiate(enemyLairPrefabs[enemyIndex],
         GenRand(),
        randomRotation);
        
    }
    //spawn enemy lairs vector
    private Vector3 GenRand()
        {
    
        float posX = Random.Range(-Xes, Xes);
        float posZ = Random.Range(-Zes, Zes);
        Vector3 random = new Vector3(posX, 5, posZ);
        return random;
        }
    void Update()
    {  
    }
    //przenies je do odpowiednich skryptow, ustaw ifa gdy gracz jest blisko kilka sekund to niszcza sie i spawnuja wilki
    void SpawnWolfs(int wolfs){

    }
     void SpawnBees(int bees){
        
    }

    void SpawnBears(int bears){
        
    }

    }
    
