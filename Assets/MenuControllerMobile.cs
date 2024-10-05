using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControllerMobile : MonoBehaviour
{
    
    [SerializeField]
    private bl_Joystick Joystick;

    [SerializeField]
    private MenuController menuController; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Joystick.Horizontal;
        float y = Joystick.Vertical; 

        Debug.Log(y);

        menuController.NavigateMenu(0, y);
    }
}
