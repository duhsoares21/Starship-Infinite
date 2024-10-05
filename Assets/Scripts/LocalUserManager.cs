using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalUserManager : MonoBehaviour, IUserManager
{
    private GameStatsManager gameStatsManager;
    private CheckAchievmentsRequirements achievmentsRequirements;

    public void StartGame()
    {
        gameStatsManager = GameObject.Find("GameStats").GetComponent<GameStatsManager>();
        achievmentsRequirements = GameObject.Find("AchievmentStats").GetComponent<CheckAchievmentsRequirements>();

        achievmentsRequirements.StartAchievments();

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
        Debug.Log("Bem-vindo, usuário local");
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
