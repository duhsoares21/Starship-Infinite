using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;
using UnityEngine.SceneManagement;
using System;

public class StartGame : MonoBehaviour
{
    private ILangSelect language;
    private IUserManager userService;
    public InputAction press_start;
    public bool audioPlay, audioPlayed, canLoadScene;

    private string selectedLanguage;

    private GameStatsManager GSM;

    void OnEnable()
    {
        press_start.Enable();
    }

    void OnDisable()
    {
        press_start.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        GSM = GameObject.Find("GameStats").GetComponent<GameStatsManager>();

        PlayerPrefs.SetInt("ColorSelected", 0);
        userService = GameObject.Find("UserService").GetComponent<UserServiceManager>().currentService;

        selectedLanguage = PlayerPrefs.GetString("SelectedLanguage", "--");
        if(selectedLanguage == "--")
        {
            GameObject.Find("Language").GetComponent<LangSelect>().SetLanguage("EN");    
        }
        else
        {
            GameObject.Find("Language").GetComponent<LangSelect>().SetLanguage(selectedLanguage);
        }
        
        language = GameObject.Find("Language").GetComponent<LangSelect>().GetLanguage();

        GetComponent<Text>().text = language.PRESS_START;

        press_start.started += StartGameMethod;
    }

    void Update()
    {
        if(audioPlay && !audioPlayed)
        {
            audioPlayed = true;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        }
    }

    public void InputDetector()
    {
        foreach (var item in PlayerInput.all[0].devices)
        {
            if(item.device is XInputController)
            {
                GSM.SetMainInput(0);
            }
            else if(item.device is DualShockGamepad)
            {
                GSM.SetMainInput(1);
            }
            else
            {
                GSM.SetMainInput(2);
            }
        }
    }

    private void StartGameMethod(InputAction.CallbackContext obj)
    {
        InputDetector();
        PlayerPrefs.SetFloat("timeOfLastButtonPress", Time.realtimeSinceStartup);
        audioPlay = true;
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene(){
        yield return new WaitForSeconds(0.85f);
        userService.StartGame();
    }
}
