using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    public bool pause = false;
    public AudioClip menuMusic;
    public int playerPausedIndex;

    void Start()
    {
        pause = false;
        Time.timeScale = 1;
    }
  
    public void Pause()
    {
        if (pause)
        {
            if (SystemInfo.deviceModel.Contains("Xbox One X"))
            {
                Application.targetFrameRate = 60;
            }
            else if(SystemInfo.deviceModel.Contains("Xbox Series X") || SystemInfo.deviceModel.Contains("Xbox Series S"))
            {
                Application.targetFrameRate = 120;
            }
            else
            {
                Application.targetFrameRate = 60;
            }
            ResumeGame();
        }
        else
        {
            Application.targetFrameRate = 30;
            PauseGame(); 
        }
    }

    void Update(){
        if(pause)
        {
            if (GameObject.Find("InputController").GetComponent<PlayerInputManager>().playerCount == 1)
            {
                if(GameObject.Find("InputController").GetComponent<PlayerInputManager>().maxPlayerCount == 2)
                {
                    GameObject.Find("InputController").GetComponent<PlayerInputManager>().maxPlayerCount = 1;
                }
            }

            if(GameObject.Find("Player2_")!=null && GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Navigate").enabled)
            {
                GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Navigate").Disable();
                GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Submit").Disable();
            }
        }
        else
        {
            if(GameObject.Find("InputController") == null)
            {
                return;
            }
            
            if(GameObject.Find("InputController").GetComponent<PlayerInputManager>().playerCount == 1)
            {
                if(GameObject.Find("InputController").GetComponent<PlayerInputManager>().maxPlayerCount == 1)
                {
                    GameObject.Find("InputController").GetComponent<PlayerInputManager>().maxPlayerCount = 2;
                }
            }
        }
    }

    public void PauseGame()
    {
        GameObject.Find("Player1_").GetComponent<Player>().disablePlayerControls();
        GameObject.Find("Player1_").GetComponent<Player>().GetComponent<PlayerInput>().actions.FindAction("Pause").Enable();
        if(GameObject.Find("Player2_")!=null)
        {

            GameObject.Find("Player2_").GetComponent<Player>().disablePlayerControls();

            GameObject.Find("Player2_").GetComponent<Player>().GetComponent<PlayerInput>().actions.FindAction("Pause").Enable();

            GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Navigate").Disable();

            GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Submit").Disable();

        }
        pause = true;
        GameObject.Find("PausePanel").GetComponent<Image>().enabled = true;
        GameObject.Find("PauseLabel").GetComponent<Text>().enabled = true;
        GameObject.Find("Quit").GetComponent<RectTransform>().GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Quit").GetComponent<RectTransform>().GetChild(1).gameObject.SetActive(true);
        Time.timeScale = 0;
        GameObject.FindWithTag("Player").GetComponent<Player>().GetComponent<PlayerInput>().actions.FindAction("Back").Enable();
    }

    public void ResumeGame()
    {
        GameObject.Find("Player1_").GetComponent<Player>().enablePlayerControls();
        if(GameObject.Find("Player2_")!=null)
        {
            GameObject.Find("Player2_").GetComponent<Player>().enablePlayerControls();
            GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Navigate").Enable();
            GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Submit").Enable();
        }
        pause = false;
        GameObject.Find("PausePanel").GetComponent<Image>().enabled = false;
        GameObject.Find("PauseLabel").GetComponent<Text>().enabled = false;
        GameObject.Find("Quit").GetComponent<RectTransform>().GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Quit").GetComponent<RectTransform>().GetChild(1).gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToMenu(InputAction.CallbackContext obj)
    {
        if(pause)
        {
            ResumeGame();
            GameObject.Find("Audio").GetComponent<AudioSource>().clip = menuMusic;
            GameObject.Find("Audio").GetComponent<AudioSource>().pitch = 1.0f;
            GameObject.Find("Audio").GetComponent<AudioSource>().volume = 0.1f;

            GameObject.Find("Audio").GetComponent<AudioSource>().Play();
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }
}
