using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2_Language : MonoBehaviour
{
    private ILangSelect language;
    // Start is called before the first frame update
    void Start()
    {
        language = GameObject.Find("Language").GetComponent<LangSelect>().GetLanguage();

        this.GetComponent<Text>().text = language.P2+" "+language.JOIN+"\n"+language.PRESS_START;
        GameObject.Find("P1_TextIndicator").GetComponent<Text>().text = language.P1;
        GameObject.Find("P2_deactivated").GetComponent<Transform>().GetChild(1).GetChild(0).GetComponent<Text>().text = language.P2;
    }
}
