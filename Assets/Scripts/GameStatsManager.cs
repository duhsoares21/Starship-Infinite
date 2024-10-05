using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatsManager : MonoBehaviour
{

    //Delegates

    public delegate void HundredMeteors();
    public delegate void TwoFifthMeteors();
    public delegate void ThousandMeteors();
    public delegate void OverEightThousand();
    public delegate void AllColors();
    public delegate void Coop();
    public delegate void CoopTenThousand();
    public delegate void LifeTimeRecord();
    public delegate void DayOfPlay();
    public delegate void AllAchievments();

    //Events

    public static event HundredMeteors OnHundredMeteors;
    public static event TwoFifthMeteors OnTwoFifthMeteors;
    public static event ThousandMeteors OnThousandMeteors;
    public static event OverEightThousand OnOverEightThousand;
    public static event AllColors OnAllColors;
    public static event Coop OnCoop;
    public static event CoopTenThousand OnCoopTenThousand;
    public static event LifeTimeRecord OnLifeTimeRecord;
    public static event DayOfPlay OnDayOfPlay;
    public static event AllAchievments OnAllAchievments;

    private string importGamertag;
    private float importPoints;
    private float importPointsR;

    private bool allAchievments;
    [SerializeField]
    private string _gamerTag;
    private int _currentPointsP1;
    private int _currentPointsP2;
    [SerializeField]
    private int _maxPoints;
    [SerializeField]
    private int _maxPointsRush;
    [SerializeField]
    private int _totalPoints;
    [SerializeField]
    private int _totalPointsRush;
    [SerializeField]
    private int _totalPointsTimeTrial;
    [SerializeField]
    private int _meteorsDestroyed;
    [SerializeField]
    private int _timesDied;
    [SerializeField]
    private int _timePlayedInGame;
    [SerializeField]
    private int _choosePurple;
    [SerializeField]
    private int _chooseOrange;
    [SerializeField]
    private int _chooseGreen;
    [SerializeField]
    private int _chooseBlue;
    [SerializeField]
    private int _choosePink;
    [SerializeField]
    private int _chooseYellow;
    [SerializeField]
    private int _chooseBlack;

    private CheckAchievmentsRequirements achievmentsRequirements;

    [SerializeField]
    private int MainInput;

    void Awake(){
        achievmentsRequirements = GameObject.Find("AchievmentStats").GetComponent<CheckAchievmentsRequirements>();

        _currentPointsP1          = 0;
        _currentPointsP2          = 0;

        
        if(PlayerPrefs.HasKey("gamertag"))
        {
            importGamertag = PlayerPrefs.GetString("gamertag");

            if(!string.IsNullOrEmpty(importGamertag))
            {
                PlayerPrefs.SetString("Gamertag", importGamertag);
                PlayerPrefs.DeleteKey("gamertag");
            }
            else
            {
                PlayerPrefs.DeleteKey("gamertag");
            }
        }
        
        if(PlayerPrefs.HasKey(PlayerPrefs.GetString("Gamertag")+"_maxPoints"))
        {
            importPoints = PlayerPrefs.GetFloat(PlayerPrefs.GetString("Gamertag")+"_maxPoints", 0);
        
            if(importPoints > 0)
            {
                PlayerPrefs.SetInt("maxPoints", int.Parse(importPoints.ToString()));
                PlayerPrefs.DeleteKey(PlayerPrefs.GetString("Gamertag")+"_maxPoints");
            }
            else
            {
                PlayerPrefs.DeleteKey("gamertag");
            }
        }

        if(PlayerPrefs.HasKey(PlayerPrefs.GetString("Gamertag")+"_maxPointsR"))
        {
            importPointsR = PlayerPrefs.GetFloat(PlayerPrefs.GetString("Gamertag")+"_maxPointsR", 0);

            if(PlayerPrefs.HasKey("gamertag"))
            {
                if(importPointsR > 0)
                {
                    PlayerPrefs.SetInt("maxPointsRush", int.Parse(importPointsR.ToString()));
                    PlayerPrefs.DeleteKey(PlayerPrefs.GetString("Gamertag")+"_maxPointsR");
                }
                else
                {
                    PlayerPrefs.DeleteKey("gamertag");
                }
            }
        }

        _gamerTag               = PlayerPrefs.GetString("Gamertag");
        _maxPoints              = PlayerPrefs.GetInt("maxPoints", 0);
        _maxPointsRush          = PlayerPrefs.GetInt("maxPointsRush", 0);
        _totalPoints            = PlayerPrefs.GetInt("totalPoints", 0);
        _totalPointsRush        = PlayerPrefs.GetInt("totalPointsRush", 0);
        _totalPointsTimeTrial   = PlayerPrefs.GetInt("totalPointsTimeTrial", 0);
        _meteorsDestroyed       = PlayerPrefs.GetInt("meteorsDestroyed", 0);
        _timesDied              = PlayerPrefs.GetInt("timesDied", 0);
        _timePlayedInGame       = PlayerPrefs.GetInt("timePlayedInGame", 0);
        _choosePurple           = PlayerPrefs.GetInt("choosePurple", 0);
        _chooseOrange           = PlayerPrefs.GetInt("chooseOrange", 0);
        _chooseGreen            = PlayerPrefs.GetInt("chooseGreen", 0);
        _chooseBlue             = PlayerPrefs.GetInt("chooseBlue", 0);
        _choosePink             = PlayerPrefs.GetInt("choosePink", 0);
        _chooseYellow           = PlayerPrefs.GetInt("chooseYellow", 0);
        _chooseBlack            = PlayerPrefs.GetInt("chooseBlack", 0);
    }

    //Getters

    public string GetGamertag(){
        return _gamerTag;
    }

    public int GetCurrentPointsP1(){
        return _currentPointsP1;
    }

    public int GetCurrentPointsP2(){
        return _currentPointsP2;
    }
    public int GetMaxPoints()
    {
        if (PlayerPrefs.GetInt("GameMode") == 0)
        {
            return _maxPoints;
        }
        else
        {
            return GetMaxPointsRush();
        }
    }

    public int GetMaxPointsRush()
    {
        return _maxPointsRush;
    }

    public int GetTotalPoints(){
        if (PlayerPrefs.GetInt("GameMode") == 0)
        {
            return _totalPoints;
        }
        else
        {
            return GetTotalPointsRush();
        }
    }

    public int GetTotalPointsRush(){
        return _totalPointsRush;
    }

    public int GetTotalPointsTimeTrial(){
        return _totalPointsTimeTrial;
    }

    public int GetMeteorsDestroyed(){
        return _meteorsDestroyed;
    }

    public int GetTimesDied(){
        return _timesDied;
    }
    
    public int GetTimePlayedInGame(){
        return _timePlayedInGame;
    }
    public List<int> GetChoosedColor(){
        List<int> colorsList = new List<int>();
        colorsList.Add(_choosePurple);
        colorsList.Add(_chooseOrange);
        colorsList.Add(_chooseGreen);
        colorsList.Add(_chooseBlue);
        colorsList.Add(_choosePink);
        colorsList.Add(_chooseYellow);
        colorsList.Add(_chooseBlack);

        colorsList.Sort();
        colorsList.Reverse();

        return colorsList;
    }
    
    public int GetMainInput(){
        return MainInput;
    }
    //Setters
    
    public void SetGamerTag(string gamertag){
        _gamerTag = gamertag;
        PlayerPrefs.SetString("Gamertag", _gamerTag);
    }

    public void SetCurrentPointsP1(int currentPointsP1)
    {
        _currentPointsP1 = currentPointsP1;
        string pointsFormat = String.Format("{0:0000000000}", _currentPointsP1);
        GameObject.Find("P1_Score").GetComponent<Text>().text = pointsFormat;

        OnCoop();
        OnCoopTenThousand();
        OnOverEightThousand();
        OnAllAchievments();
    }

    public void SetCurrentPointsP2(int currentPointsP2)
    {
        if (GameObject.Find("P2_Score") != null)
        {
            _currentPointsP2 = currentPointsP2;
            string pointsFormat = String.Format("{0:0000000000}", _currentPointsP2);
            GameObject.Find("P2_Score").GetComponent<Text>().text = pointsFormat;
        }

        OnCoop();
        OnCoopTenThousand();
        OnOverEightThousand();
        OnAllAchievments();
    }

    public void SetMaxPoints(int maxPoints)
    {
        if (PlayerPrefs.GetInt("GameMode") == 0)
        {
            _maxPoints = maxPoints;
            string hiscore = String.Format("{0:0000000000}", _maxPoints);
            GameObject.Find("HiScore").GetComponent<Text>().text = hiscore;
            PlayerPrefs.SetInt("maxPoints", _maxPoints);
        }
        else
        {
            SetMaxPointsRush(maxPoints);
        }
    }

    public void SetMaxPointsRush(int maxPointsRush)
    {
        _maxPointsRush = maxPointsRush;
        string hiscore = String.Format("{0:0000000000}", _maxPointsRush);
        GameObject.Find("HiScore").GetComponent<Text>().text = hiscore;
        PlayerPrefs.SetInt("maxPointsRush", _maxPointsRush);
    }

    public void SetTotalPoints(int totalPoints){
        if (PlayerPrefs.GetInt("GameMode") == 0)
        {
            _totalPoints = _totalPoints + totalPoints;
            PlayerPrefs.SetInt("totalPoints", _totalPoints);
        }
        else
        {
            SetTotalPointsRush(totalPoints);
        }

        OnLifeTimeRecord();
        OnAllAchievments();
    }

    public void SetTotalPointsRush(int totalPointsRush){
        _totalPointsRush = _totalPointsRush + totalPointsRush;
        PlayerPrefs.SetInt("totalPointsRush", _totalPointsRush);
        OnLifeTimeRecord();
        OnAllAchievments();
    }

    public void SetTotalPointsTimeTrial(int totalPointsTimeTrial){
        _totalPointsTimeTrial = _totalPointsTimeTrial + totalPointsTimeTrial;
        PlayerPrefs.SetInt("totalPointsTimeTrial", _totalPointsTimeTrial);
        OnLifeTimeRecord();
        OnAllAchievments();
    }

    public void SetMeteorsDestroyed(){
        _meteorsDestroyed++;
        PlayerPrefs.SetInt("meteorsDestroyed", _meteorsDestroyed);
        OnHundredMeteors();
        OnTwoFifthMeteors();
        OnThousandMeteors();
        OnAllAchievments();
    }

    public void SetTimesDied(){
        _timesDied++;
        PlayerPrefs.SetInt("timesDied", _timesDied);
    }

    public void SetTimePlayedInGame(){
        _timePlayedInGame++;
        PlayerPrefs.SetInt("timePlayedInGame", _timePlayedInGame);
        OnDayOfPlay();
        OnAllAchievments();
    }

    public void SetChooseColor(int chooseColor){
        if(chooseColor == 0)
        {
            _choosePurple++;
            PlayerPrefs.SetInt("choosePurple", _choosePurple);
        }
        else if(chooseColor == 1)
        {
            _chooseOrange++;
            PlayerPrefs.SetInt("chooseOrange", _chooseOrange);
        }
        else if(chooseColor == 2)
        {
            _chooseGreen++;
            PlayerPrefs.SetInt("chooseGreen", _chooseGreen);
        }
        else if(chooseColor == 3)
        {
            _chooseBlue++;
            PlayerPrefs.SetInt("chooseBlue", _chooseBlue);
        }
        else if(chooseColor == 4)
        {
            _choosePink++;
            PlayerPrefs.SetInt("choosePink", _choosePink);
        }
        else if(chooseColor == 5)
        {
            _chooseYellow++;
            PlayerPrefs.SetInt("chooseYellow", _chooseYellow);
        }
        else if(chooseColor == 6)
        {
            _chooseBlack++;
            PlayerPrefs.SetInt("chooseBlack", _chooseBlack);
        }
        
        OnAllColors();
        OnAllAchievments();
    }

    public void SavaAllData(){
        PlayerPrefs.Save();
    }

    public void SetMainInput(int input)
    {
        MainInput = input;
    }
}

/*
Conquistas - 1000g

Meteor Destroyer
Destroy 100 meteors in a single game on normal mode

Rush Destroyer
Destroy 250 meteors in a single game on rush mode

It's over 8.000
Do more than 8.000 points in a single game

Colorful
Played with every single ship color in any mode

Prepare for trouble
Play in co-op for the first time

Make it double
Playing in co-op do 10.000 points combined in a single game

That's a lot of points
Make 100.000 lifetime points with Player 1 in any mode combined

Ultimate Meteor Destroyer
Destroy 1000 Meteors

24 hours
Have a total of 24h of gameplay in any mode

Starship Infinite Master
Unlock all the other achievments

*/