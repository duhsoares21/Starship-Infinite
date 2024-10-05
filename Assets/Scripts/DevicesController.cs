using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UI;

public class DevicesController : MonoBehaviour
{
    private InputDevice inputDevice;
    private PlayerInputManager playerInputManager;
    // Start is called before the first frame update
    void Awake()
    {        
        playerInputManager = GetComponent<PlayerInputManager>();

        InputSystem.onActionChange += ActionChange;
    }

    void Update()
    {
        controllerDetector();
    }
    private void ActionChange(object obj, InputActionChange change)
    {
        switch (change)
        {
            case InputActionChange.ActionStarted:
                InputAction ia = (InputAction)obj;
                if(playerInputManager.playerCount == 0)
                {
                    if(ia.activeControl.device != null)
                    {
                        //playerInputManager.JoinPlayer();
                        return;
                    }
                }
                else if(playerInputManager.playerCount == 1)
                {
                    if(ia.activeControl.device != null)
                    {
                        //playerInputManager.JoinPlayer(1, -1, null, ia.activeControl.device);
                        return;
                    }
                }
                break;
            default:
                break;
        }
    }

    void controllerDetector(){
  
        if(Gamepad.all.Count <= 0)
        {
            Debug.Log("Teclado");
            
        }
        else
        {
            if(Gamepad.current is DualShockGamepad)
            {
                Debug.Log("DS4");
            }
            else if(Gamepad.current is XInputController)
            {
                Debug.Log("XBOX");
            }
            else
            {
                Debug.Log("Controle Genérico");
            }
        }
    }
}
