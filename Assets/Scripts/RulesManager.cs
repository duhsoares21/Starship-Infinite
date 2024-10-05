using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesManager : MonoBehaviour
{
    public Spawner NormalMode;
    public RushSpawner RushMode;

    enum GameMode {
        Normal,
        Rush
    }
   
    // Start is called before the first frame update
    void Awake()
    {
        int gameMode = PlayerPrefs.GetInt("GameMode");

        if(gameMode == (int)GameMode.Normal)
        {
            NormalMode.enabled = true;
        }
        else if(gameMode == (int)GameMode.Rush)
        {
            RushMode.enabled = true;
        }
    }
}
