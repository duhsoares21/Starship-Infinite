using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class DualShock4Customs : MonoBehaviour
{
    public void setLightColor(float r, float g, float b){
        if(Gamepad.current is DualShockGamepad)
        {
            Color lightColor = new Color();
                
            lightColor.r = r;
            lightColor.g = g;
            lightColor.b = b;

            DualShockGamepad.current.SetLightBarColor(lightColor);
        }
    }
}
