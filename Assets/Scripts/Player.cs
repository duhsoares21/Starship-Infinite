using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Camera camera;
    private int lastPlayerCount;
    InputsController inputActions;
    private Vector2 screenBounds;
    public float speed;
    public GameObject bullet;
    private GameObject BulletBaseL, BulletBaseR;
    private bool canShootR = true;
    private bool canShootL = true;

    private bool shootL, shootR, moveShip;
    private Vector2 coordinates;
    private int currentLayer;
    public bool playerEnabled = true;
    public bool isGamePlay = false;
    public bool enablePause = false;

    private bool checkCameraLimit = false;
    public bool JoinedPlayer = false;
    public bool ColorSelected;
    public bool finishColorSelection;
    private GameSettings GameSettings;

    public Color[] textColors;

    public void OnEnable(){
        enablePlayerControls();
    }

    public void OnDisable(){
        disablePlayerControls();
    }

    public void enablePlayerControls()
    {       
        GetComponent<PlayerInput>().actions.FindAction("Back").Enable();
        GetComponent<PlayerInput>().actions.FindAction("Pause").Enable();
        GetComponent<PlayerInput>().actions.FindAction("Move").Enable();
        GetComponent<PlayerInput>().actions.FindAction("FireLeft").Enable();
        GetComponent<PlayerInput>().actions.FindAction("FireRight").Enable();
        GetComponent<PlayerInput>().actions.FindAction("Fire").Enable();
    }

    public void disablePlayerControls(){
        GetComponent<PlayerInput>().actions.FindAction("Back").Disable();
        GetComponent<PlayerInput>().actions.FindAction("Pause").Disable();
        GetComponent<PlayerInput>().actions.FindAction("Move").Disable();
        GetComponent<PlayerInput>().actions.FindAction("FireLeft").Disable();
        GetComponent<PlayerInput>().actions.FindAction("FireRight").Disable();
        GetComponent<PlayerInput>().actions.FindAction("Fire").Disable();
    }

    void Awake(){
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        GameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        
        int totalPlayers = GameObject.Find("InputController").GetComponent<PlayerInputManager>().playerCount;

        if(totalPlayers==1)
        {
            GameObject.Find("Player").name = "Player1_";
            GameObject.Find("Body").name = "P1_Body_";
            GameObject.Find("Wings").name = "P1_Wings_";
            GameObject.Find("Cannons").name = "P1_Cannons_";
        }
        else
        {
            GameObject.Find("Player").name = "Player2_";
            GameObject.Find("Body").name = "P2_Body_";
            GameObject.Find("Wings").name = "P2_Wings_";
            GameObject.Find("Cannons").name = "P2_Cannons_";
        }

        //GameObject.Find("InputController").GetComponent<PlayerInputManager>().onPlayerJoined += PlayerJoin;
        //GameObject.Find("InputController").GetComponent<PlayerInputManager>().onPlayerLeft += PlayerLeft;
    }

    private void PlayerJoin(PlayerInput obj) {
        int totalPlayers = obj.playerIndex + 1;
        obj.camera = camera;
        screenBounds = obj.camera.ScreenToWorldPoint(new Vector3(obj.camera.pixelWidth * totalPlayers, obj.camera.pixelHeight, obj.camera.transform.position.z));      
    }

    private void PlayerLeft(PlayerInput obj) {
        int totalPlayers = obj.playerIndex + 1;
        obj.camera = camera;
        screenBounds = obj.camera.ScreenToWorldPoint(new Vector3(obj.camera.pixelWidth * totalPlayers, obj.camera.pixelHeight, obj.camera.transform.position.z));      
    }

    void Start() {
        InvokeRepeating("ShootCoolDown",0,0.1f);

        BulletBaseL = this.transform.GetChild(3).GetChild(0).gameObject;
        BulletBaseR = this.transform.GetChild(3).GetChild(1).gameObject;

        int totalPlayers = GameObject.Find("InputController").GetComponent<PlayerInputManager>().playerCount;

        screenBounds = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, camera.transform.position.z));

        if(SceneManager.GetActiveScene().name == "GamePlay")
        {    
            if(GameObject.Find("Player2_") != null)
            {
                //Vector3 P1Pos = GameObject.Find("Player1_").GetComponent<Transform>().localPosition;
                //GameObject.Find("Player1_").GetComponent<Transform>().localPosition = new Vector3(-15, P1Pos.y, P1Pos.z);
                Vector3 P2Pos = GameObject.Find("Player2_").GetComponent<Transform>().localPosition;
                GameObject.Find("Player2_").GetComponent<Transform>().localPosition = new Vector3(15, P2Pos.y, P2Pos.z);
            }
        }
        else
        {
            GetComponent<Transform>().localPosition = Vector3.zero;

            if(totalPlayers == 2)
            {
                Vector3 P1Pos = GameObject.Find("Player1_").GetComponent<Transform>().localPosition;
                GameObject.Find("Player1_").GetComponent<Transform>().localPosition = new Vector3(-15, P1Pos.y, P1Pos.z);
                Vector3 P2Pos = GameObject.Find("Player2_").GetComponent<Transform>().localPosition;
                GameObject.Find("Player2_").GetComponent<Transform>().localPosition = new Vector3(15, P2Pos.y, P2Pos.z);
            }
        }

        switch(totalPlayers)
        {
            case 1:
                SetPlayerLayer(8);
                break;
            case 2:
                SetPlayerLayer(9);
                break;
        }
    }

    void Update(){

        if(!playerEnabled)
        {
            moveShip = false;
            shootL = false;
            shootR = false;
            return;
        }

        if(SceneManager.GetActiveScene().name == "GamePlay")
        {
            if (!enablePause)
            {
                GetComponent<PlayerInput>().actions.FindAction("Back").performed -= BackToMenu;
                GetComponent<PlayerInput>().actions.FindAction("Pause").performed -= Pause;
                GetComponent<PlayerInput>().actions.FindAction("Back").performed += BackToMenu;
                GetComponent<PlayerInput>().actions.FindAction("Pause").performed += Pause;
                enablePause = true;
            }
            if(!isGamePlay)
            {
                ColorSelected = PlayerPrefs.GetInt("ColorSelected") != 0;
                
                int totalPlayers = GameObject.Find("InputController").GetComponent<PlayerInputManager>().playerCount;

                //GetComponent<PlayerInput>().actions.FindAction("Fire").performed += StartFire;
                //GetComponent<PlayerInput>().actions.FindAction("Fire").canceled += StopFire;
            
                GetComponent<PlayerInput>().actions.FindAction("FireLeft").performed += StartFireLeft;
                GetComponent<PlayerInput>().actions.FindAction("FireLeft").canceled += StopFireLeft;

                GetComponent<PlayerInput>().actions.FindAction("FireRight").performed += StartFireRight;
                GetComponent<PlayerInput>().actions.FindAction("FireRight").canceled += StopFireRight;

                GetComponent<PlayerInput>().actions.FindAction("Move").performed += MoveShip;
                GetComponent<PlayerInput>().actions.FindAction("Move").canceled += StopMoveShip;

                if(totalPlayers == 2 && !JoinedPlayer)
                {
                    JoinedPlayer = true;
                    GameObject.Find("JoinInfo").GetComponent<Text>().enabled = false;
                    if(ColorSelected)
                    {
                        finishColorSelection = true;
                        GameObject.Find("P2_deactivated").GetComponent<Transform>().GetChild(1).gameObject.SetActive(true);
                    }
                    else
                    {
                        //Body
                        GameObject.Find("Player2_").GetComponent<Transform>().GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                        GameObject.Find("Player2_").GetComponent<Transform>().GetChild(0).GetComponent<BoxCollider>().enabled = false;

                        //Wings
                        GameObject.Find("Player2_").GetComponent<Transform>().GetChild(1).GetComponent<MeshRenderer>().enabled = false;
                        GameObject.Find("Player2_").GetComponent<Transform>().GetChild(1).GetComponent<BoxCollider>().enabled = false;

                        //Burner
                        GameObject.Find("Player2_").GetComponent<Transform>().GetChild(2).GetComponent<MeshRenderer>().enabled = false;
                        ParticleSystem.EmissionModule emissionL = GameObject.Find("Player2_").GetComponent<Transform>().GetChild(2).GetChild(0).GetComponent<ParticleSystem>().emission;
                        ParticleSystem.EmissionModule emissionR = GameObject.Find("Player2_").GetComponent<Transform>().GetChild(2).GetChild(1).GetComponent<ParticleSystem>().emission;
                        emissionL.enabled = false;
                        emissionR.enabled = false;
                        
                        //Cannons
                        GameObject.Find("Player2_").GetComponent<Transform>().GetChild(3).GetComponent<MeshRenderer>().enabled = false;
                        
                        //Controls
                        
                        //GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Fire").performed -= StartFire;
                        //GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Fire").canceled -= StopFire;
                        
                        GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("FireLeft").performed -= StartFireLeft;
                        GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("FireLeft").canceled -= StopFireLeft;

                        GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("FireRight").performed -= StartFireRight;
                        GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("FireRight").canceled -= StopFireRight;

                        GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Move").performed -= MoveShip;
                        GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Move").canceled -= StopMoveShip;

                        GameObject.Find("P2_deactivated").GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);

                        GameObject.Find("ColorSelect").GetComponent<PortableColorSelect>().IniciarCorPortatil();
                        GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Navigate").started += GameObject.Find("ColorSelect").GetComponent<PortableColorSelect>().SelectP2Color;
                        GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Submit").started += FinishSelection;
                    }
                }

                camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
                screenBounds = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, camera.transform.position.z));

                checkCameraLimit = true;

                isGamePlay = true;
            }
            
            if(ColorSelected && !finishColorSelection)
            {
                finishColorSelection = true;

                GameObject.Find("P2_deactivated").GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                GameObject.Find("P2_deactivated").GetComponent<Transform>().GetChild(1).gameObject.SetActive(true);

                //Body
                GameObject.Find("Player2_").GetComponent<Transform>().GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Player2_").GetComponent<Transform>().GetChild(0).GetComponent<BoxCollider>().enabled = true;

                //Wings
                GameObject.Find("Player2_").GetComponent<Transform>().GetChild(1).GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Player2_").GetComponent<Transform>().GetChild(1).GetComponent<BoxCollider>().enabled = true;

                //Burner
                GameObject.Find("Player2_").GetComponent<Transform>().GetChild(2).GetComponent<MeshRenderer>().enabled = true;
                ParticleSystem.EmissionModule emissionL = GameObject.Find("Player2_").GetComponent<Transform>().GetChild(2).GetChild(0).GetComponent<ParticleSystem>().emission;
                ParticleSystem.EmissionModule emissionR = GameObject.Find("Player2_").GetComponent<Transform>().GetChild(2).GetChild(1).GetComponent<ParticleSystem>().emission;
                emissionL.enabled = true;
                emissionR.enabled = true;
                
                //Cannons
                GameObject.Find("Player2_").GetComponent<Transform>().GetChild(3).GetComponent<MeshRenderer>().enabled = true;

                //Controls
                GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Navigate").started -= GameObject.Find("P2_deactivated").GetComponent<Transform>().GetChild(0).gameObject.GetComponent<PortableColorSelect>().SelectP2Color;
                GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Submit").started -= FinishSelection;

                //GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Fire").performed += StartFire;
                //GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Fire").canceled += StopFire;
                
                GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("FireLeft").performed += StartFireLeft;
                GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("FireLeft").canceled += StopFireLeft;

                GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("FireRight").performed += StartFireRight;
                GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("FireRight").canceled += StopFireRight;

                GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Move").performed += MoveShip;
                GameObject.Find("Player2_").GetComponent<PlayerInput>().actions.FindAction("Move").canceled += StopMoveShip;     
            }
        }

        if(moveShip)
        {
            this.transform.localPosition = new Vector3(this.transform.position.x + ((coordinates.x * speed) * Time.deltaTime), this.transform.position.y + ((coordinates.y * speed) * Time.deltaTime), 0);
        }

        if(shootL && canShootL)
        {            
            GameObject bullL = Instantiate(bullet, new Vector3(BulletBaseL.GetComponent<Transform>().position.x, BulletBaseL.GetComponent<Transform>().position.y, 15), GetComponent<Transform>().rotation);
            if(this.name=="Player1_")
            {
                bullL.name = "BL_1";
                bullL.GetComponent<MeshRenderer>().materials[0].color = textColors[PlayerPrefs.GetInt("P1CurrentColor")];
            }
            else
            {
                bullL.name = "BL_2";
                bullL.GetComponent<MeshRenderer>().materials[0].color = textColors[PlayerPrefs.GetInt("P2CurrentColor")];
            }
            bullL.GetComponent<Bullet>().OnObjectSpawn();

            if (bullL != null)
            {
                BulletBaseL.GetComponent<AudioSource>().Play();
                canShootL = false;
            }
        }

        if(shootR && canShootR)
        {            
            GameObject bullR = Instantiate(bullet, new Vector3(BulletBaseR.GetComponent<Transform>().position.x, BulletBaseR.GetComponent<Transform>().position.y, 15), GetComponent<Transform>().rotation);
            if(this.name=="Player1_")
            {
                bullR.name = "BR_1";
                bullR.GetComponent<MeshRenderer>().materials[0].color = textColors[PlayerPrefs.GetInt("P1CurrentColor")];
            }
            else
            {
                bullR.name = "BR_2";
                bullR.GetComponent<MeshRenderer>().materials[0].color = textColors[PlayerPrefs.GetInt("P2CurrentColor")];
            }
            bullR.GetComponent<Bullet>().OnObjectSpawn();
            
            if (bullR != null)
            {
                BulletBaseR.GetComponent<AudioSource>().Play();
                canShootR = false;
            }
        }
    }

    public void Pause(InputAction.CallbackContext obj)
    {
        if (SceneManager.GetActiveScene().name != "GamePlay")
        {
            return;
        }

        if (GameObject.Find("PauseMenu").GetComponent<PauseSystem>().playerPausedIndex != 0)
        {
            if (GetComponent<PlayerInput>().playerIndex == GameObject.Find("PauseMenu").GetComponent<PauseSystem>().playerPausedIndex - 1)
            {
                GameObject.Find("PauseMenu").GetComponent<PauseSystem>().Pause();
                GameObject.Find("PauseMenu").GetComponent<PauseSystem>().playerPausedIndex = 0;
            }
        }
        else
        {
            if (GetComponent<PlayerInput>().playerIndex == 1)
            {
                GameObject.Find("PauseMenu").GetComponent<PauseSystem>().playerPausedIndex = 2;
            }
            else
            {
                GameObject.Find("PauseMenu").GetComponent<PauseSystem>().playerPausedIndex = 1;
            }

            GameObject.Find("PauseMenu").GetComponent<PauseSystem>().Pause();
        }

    }
    public void BackToMenu(InputAction.CallbackContext obj)
    {
        if (SceneManager.GetActiveScene().name != "GamePlay")
        {
            return;
        }

        if (GetComponent<PlayerInput>().playerIndex == GameObject.Find("PauseMenu").GetComponent<PauseSystem>().playerPausedIndex - 1)
        {
            if (GetComponent<PlayerInput>().playerIndex == 1)
            {
                if (GameObject.Find("PauseMenu").GetComponent<PauseSystem>().pause)
                {
                    GameObject.Find("PauseMenu").GetComponent<PauseSystem>().playerPausedIndex = 0;
                    Destroy(this.gameObject.transform.parent.gameObject);
                    GameObject.Find("P2_deactivated").GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                    GameObject.Find("P2_deactivated").GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                    GameObject.Find("JoinInfo").GetComponent<Text>().enabled = true;
                    JoinedPlayer = false;
                    ColorSelected = false;
                    finishColorSelection = false;
                    PlayerPrefs.SetInt("ColorSelected", 0);
                    GameObject.Find("PauseMenu").GetComponent<PauseSystem>().ResumeGame();
                }
            }
            else
            {
                PlayerPrefs.SetFloat("timeOfLastButtonPress", Time.realtimeSinceStartup);
                GetComponent<PlayerInput>().actions.FindAction("Back").started -= BackToMenu;
                GetComponent<PlayerInput>().actions.FindAction("Pause").performed -= Pause;
                GameObject.Find("PauseMenu").GetComponent<PauseSystem>().playerPausedIndex = 0;
                GameObject.Find("PauseMenu").GetComponent<PauseSystem>().BackToMenu(obj);
            }
        }
    }

    private void FinishSelection(InputAction.CallbackContext obj)
    {
        ColorSelected = true;
    }

    void LateUpdate() {
        if(checkCameraLimit)
        {
            CameraLimits();
        }
    }

    void CameraLimits(){
        Vector3 viewPos = this.transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + 5, screenBounds.x - 5);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + 35, screenBounds.y - 5);
        this.transform.position = viewPos;
    }

    void SetPlayerLayer(int layer){

        if(layer == 8)
        {
            this.transform.root.gameObject.tag = "P1";
        }
        else
        {
            this.transform.root.gameObject.tag = "P2";
        }

        this.transform.gameObject.layer = layer;
        
        this.transform.GetChild(0).gameObject.layer = layer;
        this.transform.GetChild(1).gameObject.layer = layer;
        this.transform.GetChild(2).gameObject.layer = layer;
        this.transform.GetChild(3).gameObject.layer = layer;
    }

    void SetLayerCameraPlayer(int layer) {
        camera.cullingMask = (1 << layer) | (1 << 0) | (1 << 10) | (1 << 11) | (1 << 12);
                
        this.transform.gameObject.layer = layer;
        
        this.transform.GetChild(0).gameObject.layer = layer;
        this.transform.GetChild(1).gameObject.layer = layer;
        this.transform.GetChild(2).gameObject.layer = layer;
        this.transform.GetChild(3).gameObject.layer = layer;
    }

    private void MoveShip(InputAction.CallbackContext obj)
    {
        coordinates = obj.ReadValue<Vector2>(); 
        moveShip = true;
    }

    private void StopMoveShip(InputAction.CallbackContext obj)
    {
        moveShip = false;
    }

    private void StopFire(InputAction.CallbackContext obj)
    {
         shootL = false;
         shootR = false;
    }

    private void StartFire(InputAction.CallbackContext obj)
    {
        shootL = true;
        shootR = true;
    }

    private void StopFireLeft(InputAction.CallbackContext obj)
    {
        shootL = false;
    }

    private void StartFireLeft(InputAction.CallbackContext obj)
    {
        shootL = true;
    }

    private void StopFireRight(InputAction.CallbackContext obj)
    {
        shootR = false;
    }

    private void StartFireRight(InputAction.CallbackContext obj)
    {
        shootR = true;
    }

    void ShootCoolDown()
    {
        if(!canShootL)
        {
            canShootL = true;
        }

        if(!canShootR)
        {
            canShootR = true;
        }
    }
}
    
