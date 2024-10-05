using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    private PlayerInputManager inputManager;

    void Start(){
        inputManager = GameObject.Find("InputController").GetComponent<PlayerInputManager>();
    }   

    void Update(){
        
    }
}
