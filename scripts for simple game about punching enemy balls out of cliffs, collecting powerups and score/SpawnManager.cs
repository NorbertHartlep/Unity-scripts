using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject powerup;
    private float bas = 9;
    public int enemyes;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerup, GenRand(), powerup.transform.rotation);
        
    }
    private Vector3 GenRand()
        {
        float posX = Random.Range(-bas, bas);
        float posZ = Random.Range(-bas, bas);
        Vector3 random = new Vector3(posX, 0, posZ);
        return random;
        }
    void SpawnEnemyWave(int howmuchenemy){
        for(int i = 0; i < howmuchenemy; i++){
        Instantiate(prefab, GenRand(), prefab.transform.rotation);
        }

         
    
    }
    // Update is called once per frame
    void Update()
    {
       enemyes = FindObjectsOfType<Enemy>().Length;
       if(enemyes == 0){
        waveNumber++;
        SpawnEnemyWave(waveNumber);
        Instantiate(powerup, GenRand(), powerup.transform.rotation);
       }
    }
}
