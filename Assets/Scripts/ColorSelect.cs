using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class ColorSelect : MonoBehaviour
{
    private bool isMap, isMap2;
    private GameObject p1, p2;
    private int currentColor = 0;
    private int currentColorB = 1;
    public Material[] colors;
    public Color[] textColors;
    private PlayerInputManager playerManager;
    private bool confirmA, confirmB;
    private ILangSelect language;

    void Start(){
        //SceneManager.UnloadSceneAsync("MainMenu");
        isMap = false;
        isMap2 = false;
        confirmA = false;
        confirmB = false;
        currentColor = 0;
        currentColorB = 1;
        language = GameObject.Find("Language").GetComponent<LangSelect>().GetLanguage();

        GameObject.Find("NavigationActivator").GetComponent<NavigationMenuActivator>().ActivateMenu();

        GameObject.Find("P1Color").GetComponent<Text>().text = language.SHIPCOLORS[0];

        GameObject.Find("TitleTop").GetComponent<Text>().text = language.COLOR_SELECT;

        GameObject.Find("SelectColor").GetComponent<Text>().text = language.SELECT_COLOR;
        GameObject.Find("Confirm").GetComponent<Text>().text = language.CONFIRM;

        GameObject.Find("P1Label").GetComponent<Text>().text = language.P1;
        GameObject.Find("P2Label").GetComponent<Text>().text = language.P2;

        if(GameObject.FindWithTag("P2") != null){
            GameObject.Find("P2Color").GetComponent<Text>().text = language.SHIPCOLORS[1];
        }
        else
        {
            GameObject.Find("P2Color").GetComponent<Text>().text = language.PRESS_START;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMap)
        {
            p1 = GameObject.FindWithTag("P1");
            
            if(p1 != null)
            {
                p1.GetComponentInChildren<PlayerInput>().actions.FindAction("Navigate").started += SelectP1Color;
                p1.GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started += SetP1Color;
                isMap = true;
            }
        }

        if(!isMap2)
        {
            p2 = GameObject.FindWithTag("P2");
            
            if(p2 != null)
            {
                p2.GetComponentInChildren<PlayerInput>().actions.FindAction("Navigate").started += SelectP2Color;
                p2.GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started += SetP2Color;

                GameObject.Find("P2Color").GetComponent<Text>().text = language.SHIPCOLORS[1];
                GameObject.Find("P2Color").GetComponent<Text>().color = textColors[1];
                GameObject.Find("P2Arrow").GetComponent<Text>().color = textColors[1];
                GameObject.Find("P2Label").GetComponent<Text>().color = textColors[1];

                GameObject.Find("P2_Body").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Body").GetComponent<MeshRenderer>().materials[0], colors[1] };
                GameObject.Find("P2_Wings").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Wings").GetComponent<MeshRenderer>().materials[0], colors[1] };
                GameObject.Find("P2_Cannons").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Cannons").GetComponent<MeshRenderer>().materials[0], colors[1] };
                GameObject.Find("Overlay").SetActive(false);
                isMap2 = true;
            }
        }
    }

    private void SetP1Color(InputAction.CallbackContext obj)
    {
        if (Time.realtimeSinceStartup - PlayerPrefs.GetFloat("timeOfLastButtonPress") < 0.5f)
        {
            return;
        }

        PlayerPrefs.SetFloat("timeOfLastButtonPress", Time.realtimeSinceStartup);
        GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetChooseColor(currentColor);
        GameObject.Find("P1_Body_").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P1_Body_").GetComponent<MeshRenderer>().materials[0], colors[currentColor]};
        GameObject.Find("P1_Wings_").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P1_Wings_").GetComponent<MeshRenderer>().materials[0], colors[currentColor]};
        GameObject.Find("P1_Cannons_").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P1_Cannons_").GetComponent<MeshRenderer>().materials[0], colors[currentColor]};    
        confirmA = true;
        PlayerPrefs.SetInt("P1CurrentColor", currentColor);
        FinishColorSelect();
    }
    
    private void SetP2Color(InputAction.CallbackContext obj)
    {
        GameObject.Find("P2_Body_").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Body_").GetComponent<MeshRenderer>().materials[0], colors[currentColorB]};
        GameObject.Find("P2_Wings_").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Wings_").GetComponent<MeshRenderer>().materials[0], colors[currentColorB]};
        GameObject.Find("P2_Cannons_").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Cannons_").GetComponent<MeshRenderer>().materials[0], colors[currentColorB]};    
        confirmB = true;
        PlayerPrefs.SetInt("ColorSelected",1);
        PlayerPrefs.SetInt("P2CurrentColor", currentColorB);
        FinishColorSelect();
    }

    private void SelectP1Color(InputAction.CallbackContext obj)
    {
        if (SceneManager.GetActiveScene().name != "ColorSelect")
        {
            return;
        }

        float x = obj.ReadValue<Vector2>().x;

        string[] ShipColors = language.SHIPCOLORS;

        if(x > 0)
        {
            if(currentColor < colors.Length-1)
            {
                currentColor++;
            }
            else
            {
                currentColor = 0;
            }
        }
        else if(x < 0)
        {
            if(currentColor > 0)
            {
                currentColor--;
            }
            else
            {
                currentColor = colors.Length - 1;
            }
        }
        
        string shipColors = ShipColors[currentColor];

        GameObject.Find("P1Color").GetComponent<Text>().text = shipColors.ToString();
        GameObject.Find("P1Color").GetComponent<Text>().color = textColors[currentColor];
        GameObject.Find("P1Arrow").GetComponent<Text>().color = textColors[currentColor];
        GameObject.Find("P1Label").GetComponent<Text>().color = textColors[currentColor];

        GameObject.Find("P1_Body").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P1_Body").GetComponent<MeshRenderer>().materials[0], colors[currentColor]};
        GameObject.Find("P1_Wings").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P1_Wings").GetComponent<MeshRenderer>().materials[0], colors[currentColor]};
        GameObject.Find("P1_Cannons").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P1_Cannons").GetComponent<MeshRenderer>().materials[0], colors[currentColor]};    
    }

    private void SelectP2Color(InputAction.CallbackContext obj)
    {
        if (SceneManager.GetActiveScene().name != "ColorSelect")
        {
            return;
        }

        float x = obj.ReadValue<Vector2>().x;

        string[] ShipColors = language.SHIPCOLORS;

        if(x > 0)
        {
            if(currentColorB < colors.Length-1)
            {
                currentColorB++;
            }
            else
            {
                currentColorB = 0;
            }
        }
        else if(x < 0)
        {
            if(currentColorB > 0)
            {
                currentColorB--;
            }
            else
            {
                currentColorB = colors.Length - 1;
            }
        }
        
        string shipColors = ShipColors[currentColorB];

        GameObject.Find("P2Color").GetComponent<Text>().text = shipColors.ToString();
        GameObject.Find("P2Color").GetComponent<Text>().color = textColors[currentColorB];
        GameObject.Find("P2Arrow").GetComponent<Text>().color = textColors[currentColorB];
        GameObject.Find("P2Label").GetComponent<Text>().color = textColors[currentColorB];

        GameObject.Find("P2_Body").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Body").GetComponent<MeshRenderer>().materials[0], colors[currentColorB] };
        GameObject.Find("P2_Wings").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Wings").GetComponent<MeshRenderer>().materials[0], colors[currentColorB] };
        GameObject.Find("P2_Cannons").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Cannons").GetComponent<MeshRenderer>().materials[0], colors[currentColorB] };
    }

    void FinishColorSelect(){
        playerManager = GameObject.Find("InputController").GetComponent<PlayerInputManager>();
        
        if (playerManager.playerCount == 1)
        {
            if(confirmA)
            {
                p1.GetComponentInChildren<PlayerInput>().actions.FindAction("Navigate").started -= SelectP1Color;
                p1.GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started -= SetP1Color;
                SceneManager.LoadSceneAsync("Loading");
            }
        }
        else if(playerManager.playerCount == 2)
        {
            if(confirmA && confirmB)
            {
                p1.GetComponentInChildren<PlayerInput>().actions.FindAction("Navigate").started -= SelectP1Color;
                p1.GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started -= SetP1Color;
                p2.GetComponentInChildren<PlayerInput>().actions.FindAction("Navigate").started -= SelectP2Color;
                p2.GetComponentInChildren<PlayerInput>().actions.FindAction("Submit").started -= SetP2Color;
                SceneManager.LoadSceneAsync("Loading");
            }
        }
    }
}
