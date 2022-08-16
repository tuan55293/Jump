using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGUI;
    public GameObject gameGUI;
    public Text scoreCountingtext;
    public Image powerSliderBar;

    public Dialog achievementDialog;
    public Dialog healthDialog;
    public Dialog gameOverDialog;


    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGameGUI(bool isShow)
    {
        if (gameGUI)
            gameGUI.SetActive(isShow);
        if(homeGUI)
            homeGUI.SetActive(!isShow);
    }
    
    public void UpdateScoreCounting(int score)
    {
        if(scoreCountingtext)
            scoreCountingtext.text = score.ToString();
    }
    public void UpdatePowerBar(float curVal, float totalVal)
    {
        if (powerSliderBar)
            powerSliderBar.fillAmount = curVal / totalVal;
    }
    public void ShowAchievementDialog()
    {
        if (achievementDialog)
            achievementDialog.Show(true);
    }
    public void ShowHealthDialog()
    {
        if(healthDialog)
            healthDialog.Show(true);
    }
    public void ShowGameOverDialog()
    {
        if (gameOverDialog)
            gameOverDialog.Show(true);
    }
}
