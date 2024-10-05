using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [SerializeField]
    private bool _canUse;

    [SerializeField]
    private bool _isActive;

    [SerializeField]
    private float _damage;
    
    [SerializeField]
    private float _duration;
    
    [SerializeField]
    private float _cooldown;

    public float getDamage(){
        return _damage;
    }

    public float getDuration(){
        return _duration;
    }

    public float getCoolDown(){
        return _cooldown;
    }

    public bool getCanUse(){
        return _canUse;
    }

    public bool getIsActive(){
        return _isActive;
    }

    public void startDuration(){
        StartCoroutine("duration");
    }

    public void startCoolDown(){
        StartCoroutine("coolDown");
    }

    IEnumerator duration(){
        if(!_isActive){
            _isActive = true;
            _canUse = false;
            yield return new WaitForSeconds(_duration);
            _isActive = false;
            StartCoroutine("coolDown");
        }
    }

     IEnumerator coolDown(){
        _canUse = false;
        yield return new WaitForSeconds(_cooldown);
        _canUse = true;
    }
}
