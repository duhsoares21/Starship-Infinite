using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    private bool hasLoaded = false;
    private bool activeScene = false;
    private ILangSelect language;
    private AsyncOperation op;
    private GameObject p1;
    private bool isMap = false; 

    void Start(){
        language = GameObject.Find("Language").GetComponent<LangSelect>().GetLanguage();

        GameObject.Find("NavigationActivator").GetComponent<NavigationMenuActivator>().ActivateMenu();

        GameObject.Find("Fire").GetComponent<Text>().text = language.SHOOT;
        GameObject.Find("Move").GetComponent<Text>().text = language.MOVE;
        GameObject.Find("PressAny").GetComponent<Text>().text = language.PRESS_START;

        p1 = GameObject.FindWithTag("P1");

        LoadLevel("GamePlay");
    }

    void Update(){    
        if(!isMap)
        {
            if(p1 != null)
            {
                p1.GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started += ContinueGame;
                if(GameObject.Find("Player2_") != null)
                {
                    GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Submit").started += ContinueGame;
                }
                isMap = true;
            }
        }
    }

    private void ContinueGame(InputAction.CallbackContext obj)
    {
        if (Time.realtimeSinceStartup - PlayerPrefs.GetFloat("timeOfLastButtonPress") < 0.5f)
        {
            return;
        }
        p1.GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started -= ContinueGame;
        if (GameObject.Find("Player2_") != null)
        {
            GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Submit").started -= ContinueGame;
        }
        PlayerPrefs.SetFloat("timeOfLastButtonPress", Time.realtimeSinceStartup);
        activeScene = true;
    }

    public void LoadLevel (string levelName)
    {
        StartCoroutine(LoadSceneAsync(levelName));
    }

    IEnumerator LoadSceneAsync ( string levelName )
    {
        op = SceneManager.LoadSceneAsync(levelName);
        op.allowSceneActivation = false;
        while ( !op.isDone )
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            if(!hasLoaded)
            {
                GameObject.Find("Progressbar").GetComponent<Slider>().value = Mathf.RoundToInt(op.progress * 100f);
            }
            
            if (op.progress >= 0.9f) {
                if(!hasLoaded)
                {
                    GameObject.Find("Progressbar").SetActive(false);
                }
                hasLoaded = true;
                GameObject.Find("PressAny").GetComponent<Text>().enabled = true;
                if(activeScene)
                {
                    op.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}