using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public int life;
    public bool gameover = false;
    private GameObject P1, P2;
    void Start()
    {
        string hiscore = String.Format("{0:0000000000}", GameObject.Find("GameStats").GetComponent<GameStatsManager>().GetMaxPoints());
        GameObject.Find("HiScore").GetComponent<Text>().text = hiscore;
        GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetCurrentPointsP1(0);
        GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetCurrentPointsP2(0);
        P1 = GameObject.Find("Player1_");
        P1.GetComponent<Player>().enablePause = false;
        P1.GetComponent<Player>().enablePlayerControls();
        P1.GetComponent<ShipStats>().setHp(100);

        if (GameObject.Find("Player2_") != null)
        {
            P2 = GameObject.Find("Player2_");
            P2.GetComponent<Player>().enablePlayerControls();
            P2.GetComponent<ShipStats>().setHp(100);

            P2.GetComponent<Player>().isGamePlay = false;
            P2.GetComponent<Player>().JoinedPlayer = false;
            P2.GetComponent<Player>().finishColorSelection = false;

            Vector3 P1Pos = GameObject.Find("Player1_").GetComponent<Transform>().localPosition;
            GameObject.Find("Player1_").GetComponent<Transform>().localPosition = new Vector3(-15, 1.2f, P1Pos.z);
            Vector3 P2Pos = GameObject.Find("Player2_").GetComponent<Transform>().localPosition;
            GameObject.Find("Player2_").GetComponent<Transform>().localPosition = new Vector3(15, 1.2f, P2Pos.z);
        }
        else
        {
            Vector3 P1Pos = GameObject.Find("Player1_").GetComponent<Transform>().localPosition;
            GameObject.Find("Player1_").GetComponent<Transform>().localPosition = new Vector3(0, 1.2f, P1Pos.z);
        }

        setLife(3);
    }

    public int getLife()
    {
        return life;
    }

    public void setLife(int _life)
    {
        life = _life;
        if(SceneManager.GetActiveScene().name == "GamePlay")
        {
            if(GameObject.Find("vida") != null)
            {
                GameObject.Find("vida").GetComponent<Text>().text = "= "+life;
            }
        }
    }
}
