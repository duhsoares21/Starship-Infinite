using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class DeviceDebug : MonoBehaviour
{
    public InputAction press_select;
    public InputAction press_lb;
    public InputAction press_rb;
    private int currentResolution = 0;
    float deltaTime = 0.0f;
    public GameObject _RESOLUTION, _TYPE, _MODEL, _TARGET, _FPS;
    private int currentFramerate = 0;

    void OnEnable()
    {
        press_select.Enable();
        press_lb.Enable();
        press_rb.Enable();
    }

    void OnDisable()
    {
        press_select.Disable();
        press_lb.Disable();
        press_rb.Disable();
    }

    void Start()
    {
        press_select.started += ChangeResolution;
        press_rb.started += ChangeFrameRate;
        press_lb.started += HideDebug;

        Screen.SetResolution(2560, 1440, Screen.fullScreen);
        _RESOLUTION.GetComponent<Text>().text = "Resolution: 2560 x 1440 (QHD)";
        currentResolution = 4;

        Application.targetFrameRate = 120;
        _TARGET.GetComponent<Text>().text = "Target: 120FPS";
        currentFramerate = 3;

        _TYPE.GetComponent<Text>().text = "Type: "+SystemInfo.deviceType;
        _MODEL.GetComponent<Text>().text = "Model: "+SystemInfo.deviceModel;
    }

    private void HideDebug(InputAction.CallbackContext obj)
    {
        if(_RESOLUTION.GetComponent<Text>().enabled)
        {
            _RESOLUTION.GetComponent<Text>().enabled = false;
            _TYPE.GetComponent<Text>().enabled = false;
            _MODEL.GetComponent<Text>().enabled = false;
            _TARGET.GetComponent<Text>().enabled = false;
            _FPS.GetComponent<Text>().enabled = false;
        }
        else
        {
            _RESOLUTION.GetComponent<Text>().enabled = true;
            _TYPE.GetComponent<Text>().enabled = true;
            _MODEL.GetComponent<Text>().enabled = true;
            _TARGET.GetComponent<Text>().enabled = true;
            _FPS.GetComponent<Text>().enabled = true;
        }
    }

    private void ChangeResolution(InputAction.CallbackContext obj)
    {
        
        if(currentResolution==0){
            Screen.SetResolution(1280, 720, Screen.fullScreen);
            _RESOLUTION.GetComponent<Text>().text = "Resolution: 1280 x 720 (HD)";
            currentResolution = 1;
        }
        else if(currentResolution == 1)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
            _RESOLUTION.GetComponent<Text>().text = "Resolution: 1920 x 1080 (FHD)";
            currentResolution = 2;
        }
        else if(currentResolution == 2)
        {
            Screen.SetResolution(1600, 900, Screen.fullScreen);
            _RESOLUTION.GetComponent<Text>().text = "Resolution: 1600 x 900 (HD+)";
            currentResolution = 3;
        }
        else if(currentResolution == 3)
        {
            Screen.SetResolution(2560, 1440, Screen.fullScreen);
            _RESOLUTION.GetComponent<Text>().text = "Resolution: 2560 x 1440 (QHD)";
            currentResolution = 4;
        }
        else if(currentResolution == 4)
        {
            Screen.SetResolution(3840, 2160, Screen.fullScreen);
            _RESOLUTION.GetComponent<Text>().text = "Resolution: 3840 x 2160 (4K)";
            currentResolution = 0;
        }
    }

    private void ChangeFrameRate(InputAction.CallbackContext obj)
    {
        if(currentFramerate==0){
            Application.targetFrameRate = 30;
            _TARGET.GetComponent<Text>().text = "Target: 30FPS";
            currentFramerate = 1;
        }
        else if(currentFramerate==1){
            Application.targetFrameRate = 60;
            _TARGET.GetComponent<Text>().text = "Target: 60FPS";
            currentFramerate = 2;
        }
        else if(currentFramerate==2){
            _TARGET.GetComponent<Text>().text = "Target: 120FPS";
            Application.targetFrameRate = 120;
            currentFramerate = 3;
        }
        else if(currentFramerate==3){
            _TARGET.GetComponent<Text>().text = "Target: Unlocked";
            Application.targetFrameRate = 300;
            currentFramerate = 0;
        }
        
    }

	void Update()
	{
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        _FPS.GetComponent<Text>().text = "FPS: "+Mathf.Ceil(fps)+" fps";
	}
}
