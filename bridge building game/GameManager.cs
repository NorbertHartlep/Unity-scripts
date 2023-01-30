using System.Reflection.Emit;
using System.Threading;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static Dictionary<Vector2, Point> AllPoints = new Dictionary<Vector2, Point>();

    public float LevelBudget = 1000;
    public float CurrentBudget = 0;
    public UIManager myUIManager;
    public void Awake()
    {
        AllPoints.Clear();
        Time.timeScale = 0;
        CurrentBudget = LevelBudget;
        myUIManager.UpdateBudgetUI(CurrentBudget,LevelBudget);
    }
   public bool CanPlaceItem(float itemCost) 
   {
    if(itemCost > CurrentBudget) return false;
    else return true;
   }
    
    public void UpdateBudget(float itemCost)
    {
        CurrentBudget -= itemCost;
         myUIManager.UpdateBudgetUI(CurrentBudget,LevelBudget);
    }
}