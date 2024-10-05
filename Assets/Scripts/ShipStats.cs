using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipStats : MonoBehaviour
{

    public float _hp;

    private GameObject LifeBar;
    
    private void Start() {
        setHp(100);
    }

    public float getHp()
    {
        return _hp;
    }

    

    public void setHp(float hp)
    {
        _hp = hp;
        
        if(hp >= 70){
            GetComponent<DualShock4Customs>().setLightColor(0f, 1f, 0f);
        }
        else if(hp >= 41){
            GetComponent<DualShock4Customs>().setLightColor(1f, 1f, 0f);
        }
        else
        {
            GetComponent<DualShock4Customs>().setLightColor(1f, 0f, 0f);
        }

        if(this.name=="Player1_")
        {
            LifeBar = GameObject.Find("P1_Lifebar");
        }
        else if(this.name=="Player2_")
        {
            LifeBar = GameObject.Find("P2_Lifebar");
        }

        if(SceneManager.GetActiveScene().name == "GamePlay")
        {
            if(LifeBar != null)
            {
                LifeBar.GetComponent<Slider>().value = _hp;
            }
        }
    }
}
