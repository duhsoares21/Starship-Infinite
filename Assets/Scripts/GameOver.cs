using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private bool hasGameover = false;
    void Update()
    {
        if(GameObject.Find("Player1_").GetComponent<Transform>().GetChild(0).GetComponent<ShipCollision>().gameover && !hasGameover)
        {
            hasGameover = true;
            //StartCoroutine("GameOverRoutine");
        }
    }
    IEnumerator GameOverRoutine(){
        int P1Score = GameObject.Find("GameStats").GetComponent<GameStatsManager>().GetCurrentPointsP1();
        int P2Score = GameObject.Find("GameStats").GetComponent<GameStatsManager>().GetCurrentPointsP2();
        int hiscore = P1Score > P2Score ? P1Score : P2Score;

        if (hiscore > GameObject.Find("GameStats").GetComponent<GameStatsManager>().GetMaxPoints())
        {
            GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetMaxPoints(hiscore);
        }

        yield return new WaitForSeconds(3f);
        GameObject.Find("GameOver").GetComponent<Text>().enabled = false;
        hasGameover = false;
        GameObject.Find("Player1_").GetComponent<Transform>().GetChild(0).GetComponent<ShipCollision>().gameover = false;
        GameObject.Find("Main Camera").GetComponent<GameplayMusic>().SetMenuMusic();
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
