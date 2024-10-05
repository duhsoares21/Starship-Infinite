using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LangSelect : MonoBehaviour
{
    public bool BR, EN, ES, CN, AR, JP, KR, RU, PL;
    public LANG_BR lang_br;
    public LANG_EN lang_en;
    public LANG_ES lang_es;
    public LANG_CN lang_cn;
    public LANG_AR lang_ar;
    public LANG_JP lang_jp;
    public LANG_KR lang_kr;
    public LANG_RU lang_ru;
    public LANG_PL lang_pl;
    public string[] languages;
    public string[] languages_code;
    private string selectedLanguage;
    private int i;
    private bool isMap;
    private ILangSelect lang_current;
    public InputAction LangNaviagteMenu;
    public InputAction LangSelectMenu;

    void OnEnable()
    {
        LangNaviagteMenu.Enable();
        LangSelectMenu.Enable();
    }

    void OnDisable()
    {
        LangNaviagteMenu.Disable();
        LangSelectMenu.Disable();
    }

    void Awake(){
        lang_br = GetComponent<LANG_BR>();
        lang_en = GetComponent<LANG_EN>();
        lang_es = GetComponent<LANG_ES>();
        lang_cn = GetComponent<LANG_CN>();
        lang_ar = GetComponent<LANG_AR>();
        lang_jp = GetComponent<LANG_JP>();
        lang_kr = GetComponent<LANG_KR>();
        lang_ru = GetComponent<LANG_RU>();
        lang_pl = GetComponent<LANG_PL>();

        int codeID = CodeToID(PlayerPrefs.GetString("SelectedLanguage", "EN"));
        selectedLanguage = languages[codeID];

        i = codeID;
    }

    void Update()
    {
        if(!isMap)
        {
            if(SceneManager.GetActiveScene().name == "LanguageSelect")
            {
                LangNaviagteMenu.started += NavigateMenuLang;
                LangSelectMenu.started += SelectMenuLang;
                GameObject.Find("LanguageLabel").GetComponent<Text>().text = "< "+selectedLanguage+" >";    
                isMap = true;
            }
        }
    }
    private int CodeToID (string langID)
    {
        int idCode;

        if(langID == "BR")
        {
            idCode = 0;
        }
        else if(langID == "EN")
        {
            idCode = 1;
        }
        else if(langID == "ES")
        {
            idCode = 2;
        }
        else if(langID == "CN")
        {
            idCode = 3;
        }
        else if(langID == "AR")
        {
            idCode = 4;
        }
        else if(langID == "JP")
        {
            idCode = 5;
        }
        else if(langID == "KR")
        {
            idCode = 6;
        }
        else if(langID == "RU")
        {
            idCode = 7;
        }
        else if(langID == "PL")
        {
            idCode = 8;
        }
        else
        {
            idCode = 1;
        }

        return idCode;
    }

    private void SelectMenuLang(InputAction.CallbackContext obj)
    {
        if (Time.realtimeSinceStartup - PlayerPrefs.GetFloat("timeOfLastButtonPress") < 1.35f)
        {
            return;
        }

        PlayerPrefs.SetFloat("timeOfLastButtonPress", Time.realtimeSinceStartup);
        LangNaviagteMenu.started -= NavigateMenuLang;
        LangSelectMenu.started -= SelectMenuLang;
        SetLanguage(languages_code[i]);
        PlayerPrefs.SetString("SelectedLanguage", languages_code[i]);
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void NavigateMenuLang(InputAction.CallbackContext obj) 
    {
        float x = obj.ReadValue<Vector2>().x;

        if(x > 0)
        {
            if(i < 8)
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
        else if(x < 0)
        {
            if(i > 0)
            {
                i--;
            }
            else
            {
                i = languages.Length - 1;
            }
        }

        selectedLanguage = languages[i];

        GameObject.Find("LanguageLabel").GetComponent<Text>().text = "< "+selectedLanguage+" >";
    }

    public ILangSelect GetLanguage()
    {
        if(BR)
        {
            lang_current = lang_br;
        }
        else if(EN)
        {
            lang_current = lang_en;
        }
        else if(ES)
        {
            lang_current = lang_es;
        }
        else if(CN)
        {
            lang_current = lang_cn;
        }
        else if(AR)
        {
            lang_current = lang_ar;
        }
        else if(JP)
        {
            lang_current = lang_jp;
        }
        else if(KR)
        {
            lang_current = lang_kr;
        }
        else if(RU)
        {
            lang_current = lang_ru;
        }
        else if(PL)
        {
            lang_current = lang_pl;
        }
        else
        {
            lang_current = lang_en;
        }

        return lang_current;
    }

    public void SetLanguage(string langID)
    {
        BR = false;
        EN = false;
        ES = false;
        CN = false;
        AR = false;
        JP = false;
        KR = false;
        RU = false;
        PL = false;

        if(langID == "BR")
        {
            BR = true;
        }
        else if(langID == "EN")
        {
            EN = true;
        }
        else if(langID == "ES")
        {
            ES = true;
        }
        else if(langID == "CN")
        {
            CN = true;
        }
        else if(langID == "AR")
        {
            AR = true;
        }
        else if(langID == "JP")
        {
            JP = true;
        }
        else if(langID == "KR")
        {
            KR = true;
        }
        else if(langID == "RU")
        {
            RU = true;
        }
        else if(langID == "PL")
        {
            PL = true;
        }
        else
        {
            EN = true;
        }
    }
}
