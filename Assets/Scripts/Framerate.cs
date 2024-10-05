using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Framerate : MonoBehaviour
{
    void Update()
    {
        float fps = 1 / Time.unscaledDeltaTime;
        GameObject.Find("FPS").GetComponent<Text>().text = "FPS: " + Mathf.RoundToInt(fps);
    }
}
