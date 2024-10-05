using UnityEngine;

public class GameplaySpecs : MonoBehaviour
{
    void Awake()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
            Application.targetFrameRate = 30;
        }
        else
        {
            if (SystemInfo.deviceModel.Contains("Xbox One X"))
            {
                Screen.SetResolution(3840, 2160, Screen.fullScreen);
                Application.targetFrameRate = 60;
            }
            else if(SystemInfo.deviceModel.Contains("Xbox Series X"))
            {
                Screen.SetResolution(3840, 2160, Screen.fullScreen);
                Application.targetFrameRate = 120;
            }
            else if(SystemInfo.deviceModel.Contains("Xbox Series S"))
            {
                Screen.SetResolution(2560, 1440, Screen.fullScreen);
                Application.targetFrameRate = 120;
            }
            else
            {
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                Application.targetFrameRate = 60;
            }
        }
    }
}
