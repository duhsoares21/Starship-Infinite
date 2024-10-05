using UnityEngine;
using UnityEngine.SceneManagement;

public class SteamUserManager : MonoBehaviour, IUserManager
{
    private GameStatsManager gameStatsManager;
    
    public void StartGame()
    {
        gameStatsManager = GameObject.Find("GameStats").GetComponent<GameStatsManager>();

        if(CheckUserExists())
        {
            LoginUser();
        }
        else
        {
            CreateUser();
        }
    }

    public void LoginUser()
    {
        Debug.Log("Bem-vindo à Steam");
        SceneManager.LoadSceneAsync("LanguageSelect");
    }

    public void CreateUser()
    {
        gameStatsManager.SetGamerTag("Player1");

        if(CheckUserExists())
        {
            LoginUser();
        }
        else
        {
            Debug.Log("Erro ao criar usuário");
        }
    }

    public bool CheckUserExists()
    {
        if(!string.IsNullOrEmpty(gameStatsManager.GetGamertag()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
