using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixresolution : MonoBehaviour
{
    void Awake()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
        }
        else
        {
            if (SystemInfo.deviceModel.Contains("Xbox One X") || SystemInfo.deviceModel.Contains("Xbox Series X"))
            {
                Screen.SetResolution(3840, 2160, Screen.fullScreen);;
            }
            else if(SystemInfo.deviceModel.Contains("Xbox Series S"))
            {
                Screen.SetResolution(2560, 1440, Screen.fullScreen);
            }
            else
            {
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
            }
        }
        Application.targetFrameRate = 30;
    }
}
