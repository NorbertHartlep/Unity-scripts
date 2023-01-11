using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    //todo player odchodzi do tylu przy strzelaniu, naliczanie konkretnych rodzajow pkt i spawnowanie
    
    public Text highScore;
    public static float score = 0;
    public static bool havePowerup = false;
    public static float timeRemaining;
    // Start is called before the first frame update

    public static float bearDestroy;
    public static float beeDestroy;
    public static float wolfDestroy;
    public static bool isDestroying = false;
    public static void AddToScore(int AddToScore)
     {
        if(havePowerup == true){
            score += 2 * AddToScore;
            Debug.Log(AddToScore * 2);
        }
        else 
        score += AddToScore;
        Debug.Log(AddToScore);
        
    }
    void Start()
    {
        highScore.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {  
    }
}
