using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAchievmentsRequirements : MonoBehaviour
{
    //Variables

    private GameStatsManager gameStatsManager;

    //Methods
    
    public void StartAchievments()
    {
        gameStatsManager = GameObject.Find("GameStats").GetComponent<GameStatsManager>();   
       
        GameStatsManager.OnHundredMeteors += DestroyedHundredMeteors;
        GameStatsManager.OnTwoFifthMeteors += DestroyedTwoFifthMeteors;
        GameStatsManager.OnThousandMeteors += DestroyedThousandMeteors;
        GameStatsManager.OnOverEightThousand += ItsOverEightThousand;
        GameStatsManager.OnAllColors += PickedAllColors;
        GameStatsManager.OnCoop += PlayedInCoop;
        GameStatsManager.OnCoopTenThousand += PlayedInCoopTenThousand;
        GameStatsManager.OnLifeTimeRecord += ReachedLifeTimeRecord;
        GameStatsManager.OnDayOfPlay += OneDayOfPlay;
        GameStatsManager.OnAllAchievments += UnlockedAllAchievments;
    }
    private void DestroyedHundredMeteors()
    {
        if(gameStatsManager.GetMeteorsDestroyed() >= 100)
        {
            Debug.Log(1);
        }
    }
    private void DestroyedTwoFifthMeteors()
    {
         if(gameStatsManager.GetMeteorsDestroyed() >= 250)
         {
            Debug.Log(2);
         }
    }
    private void DestroyedThousandMeteors()
    {
        if(gameStatsManager.GetMeteorsDestroyed() >= 1000)
        {
            Debug.Log(3);
        }
    }
    private void ItsOverEightThousand()
    {
        if(gameStatsManager.GetCurrentPointsP1() + gameStatsManager.GetCurrentPointsP2() > 8000)
        {
            Debug.Log(4);
        }
    }
    private void PickedAllColors()
    {
        List<int> colorList = gameStatsManager.GetChoosedColor();

        bool pickedAllColors = true;

        foreach (var colorSelected in colorList)
        {
            if(colorSelected <= 0)
            {
                pickedAllColors = false;
            }
        }

        if(pickedAllColors)
        {
            Debug.Log(5);
        }
    }
    private void PlayedInCoop()
    {
        if(gameStatsManager.GetCurrentPointsP1() > 0 && gameStatsManager.GetCurrentPointsP2() > 0)
        {
            Debug.Log(6);
        }
    }
    private void PlayedInCoopTenThousand()
    {
        if(gameStatsManager.GetCurrentPointsP1() + gameStatsManager.GetCurrentPointsP2() >= 10000)
        {
            Debug.Log(7);
        }
    }
    private void ReachedLifeTimeRecord()
    {
        if(gameStatsManager.GetTotalPoints() + gameStatsManager.GetTotalPointsRush() + gameStatsManager.GetTotalPointsTimeTrial() >= 100000)
        {
            Debug.Log(8);
        }
    } 
    private void OneDayOfPlay(){
        if(gameStatsManager.GetTimePlayedInGame() >= 86400)
        {
            Debug.Log(9);
        }
    }
    private void UnlockedAllAchievments()
    {
        Debug.Log(10);
    }
    
}
