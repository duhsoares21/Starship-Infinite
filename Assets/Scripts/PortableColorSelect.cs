using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PortableColorSelect : MonoBehaviour
{
    private ILangSelect language;
    private int currentColorB = 1;
    public Material[] colors;

    public void IniciarCorPortatil()
    {
        language = GameObject.Find("Language").GetComponent<LangSelect>().GetLanguage();
        currentColorB = 0;
        PlayerPrefs.SetInt("P2CurrentColor", currentColorB);
        this.GetComponent<Text>().text = language.COLOR_SELECT + "\n\n< " + language.SHIPCOLORS[currentColorB] + " >";
    }

    public void SelectP2Color(InputAction.CallbackContext obj)
    {
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

        this.GetComponent<Text>().text = language.COLOR_SELECT+"\n\n< "+shipColors.ToString()+" >";

        GameObject.Find("P2_Body_").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Body_").GetComponent<MeshRenderer>().materials[0], colors[currentColorB] };
        GameObject.Find("P2_Wings_").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Wings_").GetComponent<MeshRenderer>().materials[0], colors[currentColorB] };
        GameObject.Find("P2_Cannons_").GetComponent<MeshRenderer>().materials = new Material[2] { GameObject.Find("P2_Cannons_").GetComponent<MeshRenderer>().materials[0], colors[currentColorB] };

        PlayerPrefs.SetInt("P2CurrentColor", currentColorB);
    }
}
