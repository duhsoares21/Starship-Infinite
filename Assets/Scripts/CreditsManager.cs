using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    private ILangSelect language;
    // Start is called before the first frame update
    void Start()
    {
        language = GameObject.Find("Language").GetComponent<LangSelect>().GetLanguage();

        GameObject.Find("TitleBottom").GetComponent<Text>().text = language.CREDITS;
        GameObject.Find("GameBy").GetComponent<Text>().text = language.GAME_BY;
        GameObject.Find("MusicBy").GetComponent<Text>().text = language.MUSIC_BY;
        GameObject.Find("PublishedBy").GetComponent<Text>().text = language.PUBLISHER;

        GameObject.Find("Audio").GetComponent<AudioSource>().volume = 0;
        GameObject.Find("CreditsMusic").GetComponent<AudioSource>().volume = 0.24f;
        GameObject.FindWithTag("P1").GetComponentInChildren<PlayerInput>().actions.FindAction("Cancel").performed += BackToMenu;
    }

    private void BackToMenu(InputAction.CallbackContext obj)
    {
        GameObject.Find("Audio").GetComponent<AudioSource>().volume = 0.1f;
        GameObject.Find("CreditsMusic").GetComponent<AudioSource>().volume = 0;
        SceneManager.LoadSceneAsync("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
