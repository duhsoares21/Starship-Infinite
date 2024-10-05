using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private bool isMap = false;
    private int currentMenuV = 0;
    private int currentMenuH = 0;
    
    [SerializeField]
    private PlayerInputManager playerInputManager;

    [SerializeField]
    private GameObject[] MenuTops;
    
    [SerializeField]
    private GameObject[] MenuBottoms;

    private ILangSelect language;

    enum Menus
    {
        StartGame,
        Credits
    }

    enum GameMode
    {
        normal,
        rush
    }

    void Start(){
        isMap = false;
        language = GameObject.Find("Language").GetComponent<LangSelect>().GetLanguage();

        GameObject.Find("NavigationActivator").GetComponent<NavigationMenuActivator>().ActivateMenu();

        GameObject.Find("NormalMode").GetComponent<Text>().text = language.NORMAL;
        GameObject.Find("RushMode").GetComponent<Text>().text = "- "+language.RUSH+" -";
        GameObject.Find("Credit").GetComponent<Text>().text = language.CREDITS;

        GameObject.Find("SelectMode").GetComponent<Text>().text = language.SELECT_MODE;
        GameObject.Find("Confirm").GetComponent<Text>().text = language.CONFIRM;
    } 

    // Update is called once per frame
    void Update()
    {
        if(playerInputManager.playerCount == 1)
        {
            if(!isMap)
            {
                if(GameObject.FindWithTag("P1") != null)
                {
                    GameObject.FindWithTag("P1").GetComponentInChildren<PlayerInput>().actions.FindAction("Navigate").started += ActionNavigateMenu;
                    GameObject.FindWithTag("P1").GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started += ActionSelectMenu;
                    isMap = true;
                }
            }
        }
        else if(playerInputManager.playerCount == 2)
        {
            if(!isMap)
            {
                if(GameObject.FindWithTag("P1") != null)
                {
                    GameObject.FindWithTag("P1").GetComponentInChildren<PlayerInput>().actions.FindAction("Navigate").started += ActionNavigateMenu;
                    GameObject.FindWithTag("P1").GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started += ActionSelectMenu;
                }
                
                isMap = true;
            }
        }
    }

    public void ActionSelectMenu(InputAction.CallbackContext obj)
    {
        SelectMenu();
    }

    public void SelectMenu(){
        if (Time.realtimeSinceStartup - PlayerPrefs.GetFloat("timeOfLastButtonPress") < 0.5f)
        {
            return;
        }

        PlayerPrefs.SetFloat("timeOfLastButtonPress", Time.realtimeSinceStartup);

        if (currentMenuV == (int) Menus.StartGame)
        {
            if (currentMenuH == (int) GameMode.normal)
            {
                PlayerPrefs.SetInt("GameMode", (int) GameMode.normal);
            }
            else if(currentMenuH == (int) GameMode.rush)
            {
                PlayerPrefs.SetInt("GameMode", (int) GameMode.rush);
            }
            
            PlayerPrefs.Save();

            GameObject.FindWithTag("P1").GetComponentInChildren<PlayerInput>().actions.FindAction("Navigate").started -= ActionNavigateMenu;
            GameObject.FindWithTag("P1").GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started -= ActionSelectMenu;

            SceneManager.LoadSceneAsync("ColorSelect");
        }
        else if(currentMenuV == (int)Menus.Credits)
        {
            SceneManager.LoadSceneAsync("Credits");
        }
    }

    public void StartGame(){
        if (currentMenuH == (int) GameMode.normal)
        {
            PlayerPrefs.SetInt("GameMode", (int) GameMode.normal);
        }
        else if(currentMenuH == (int) GameMode.rush)
        {
            PlayerPrefs.SetInt("GameMode", (int) GameMode.rush);
        }
        
        PlayerPrefs.Save();

        GameObject.FindWithTag("P1").GetComponentInChildren<PlayerInput>().actions.FindAction("Navigate").started -= ActionNavigateMenu;
        GameObject.FindWithTag("P1").GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started -= ActionSelectMenu;

        SceneManager.LoadSceneAsync("ColorSelect");
    }

    void SetMenuGraphic(int v, int h){

        foreach (GameObject menuTop in MenuTops)
        {
            menuTop.GetComponent<Text>().color = new Color(255, 255, 255);
        }

        foreach (GameObject menuBottom in MenuBottoms)
        {
            menuBottom.GetComponent<Text>().color = new Color(255, 255, 255);
        }

        MenuTops[v].GetComponent<Text>().color = new Color(1, 0.8705882f, 0.3921569f);

        if(v == (int)Menus.StartGame)
        {
            MenuBottoms[0].GetComponent<Text>().color = new Color(0.5215687f, 0.5019608f, 0.6784314f);
        }

        if(h == (int)GameMode.normal)
        {
            MenuBottoms[0].GetComponent<Text>().text = "- "+language.NORMAL+" -";
        }
        else if(h == (int)GameMode.rush)
        {
            MenuBottoms[0].GetComponent<Text>().text = "- "+language.RUSH+" -";
        }
    }

    public void ActionNavigateMenu(InputAction.CallbackContext obj) {
        
        float x = obj.ReadValue<Vector2>().x;
        float y = obj.ReadValue<Vector2>().y;

        NavigateMenu(x, y);
    }

    public void NavigateMenu(float x, float y){
        if(currentMenuV == 0)
        {
            if(x != 0)
            {
                if(x > 0)
                {
                    if(currentMenuH == 0)
                    {
                        currentMenuH++;  
                    }
                    else
                    {
                        currentMenuH--;  
                    }
                }
                else
                {
                    if(currentMenuH == 1)
                    {
                        currentMenuH--;
                    }
                    else
                    {
                        currentMenuH++;
                    }
                }
            }
        }

        if(y != 0)
        {
            if(y < 0)
            {
                if(currentMenuV == 0)
                {
                    currentMenuV++;       
                }
                else
                {
                    currentMenuV--;
                }
            }
            else
            {
                if(currentMenuV == 1)
                {
                    currentMenuV--;       
                }
                else
                {
                    currentMenuV++;
                }
            }
        }

        SetMenuGraphic(currentMenuV, currentMenuH);
    }
}
