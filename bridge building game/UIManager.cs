using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehavoiur
{
    public Button RoadButton;
    public Button WoodButton; 
    public BarCreator barCreator;
    public Slider BudgetSlider;
    public Text BudgetText;
    public Gradient myGradient;

    private void Start()
    {
       RoadButton.onClick.Invoke();
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ChangeBar(int myBarType)
    {
        if(myBarType == 0)
        {
            WoodButton.GetComponent<Outline>().enabled = false;
            RoadButton.GetComponent<Outline>().enabled = true;
            barCreator.BarToInstantiate = barCreator.RoadBar;
        }
         if(myBarType == 1)
        {
            WoodButton.GetComponent<Outline>().enabled = true;
            RoadButton.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.WoodBar;
        }
    }

    public void UpdateBudgetUI(float CurrentBudget, float LevelBudget)
    {
        BudgetText.text = MathF.FloorToInt(CurrentBudget).ToString() + "$";
        BudgetSlider.value = CurrentBudget/LevelBudget;
        BudgetSlider.fillRect.GetComponent<Image>().color = myGradient.Evaluate(BudgetSlider.value);
    }
}