
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyStats : MonoBehaviour
{
    public GameObject _meteorcollision;

    private GameObject _statsManager;

    private GameObject _ship;

    [SerializeField]
    private float _hp;
    
    [SerializeField]
    private float _damage;
    
    [SerializeField]
    private int _points;

    public float getDamage()
    {
        return _damage;
    }

    private void Start() {
        _ship = GameObject.FindGameObjectWithTag("Player");
        _statsManager = GameObject.Find("GameStatsManager");
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "bullet")
        {
            GameObject meteorCollision = Instantiate(_meteorcollision, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            meteorCollision.GetComponent<MeteorExplode>().OnObjectSpawn();

            _hp -= other.gameObject.GetComponent<WeaponStats>().getDamage();

            if(other.gameObject.name=="BL_1" || other.gameObject.name=="BR_1")
            {
                GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetCurrentPointsP1(GameObject.Find("GameStats").GetComponent<GameStatsManager>().GetCurrentPointsP1() + _points);
            }

            if(other.gameObject.name=="BL_2" || other.gameObject.name=="BR_2")
            {
                GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetCurrentPointsP2(GameObject.Find("GameStats").GetComponent<GameStatsManager>().GetCurrentPointsP2() + _points);
            }

            if(other.gameObject.name=="BL_1" || other.gameObject.name=="BR_1")
            {
                GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetTotalPoints(_points);
            }

            int P1Score = GameObject.Find("GameStats").GetComponent<GameStatsManager>().GetCurrentPointsP1();
            int P2Score = GameObject.Find("GameStats").GetComponent<GameStatsManager>().GetCurrentPointsP2();
            int hiscore = P1Score > P2Score ? P1Score : P2Score;

            if (hiscore > GameObject.Find("GameStats").GetComponent<GameStatsManager>().GetMaxPoints())
            {
                GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetMaxPoints(hiscore);
            }

            Destroy(other.gameObject);

            if (_hp <= 0)
            {
                if(other.gameObject.name=="BL_1" || other.gameObject.name=="BR_1")
                {
                    GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetMeteorsDestroyed();
                }

                Destroy(gameObject);
            }
        }
        
        if(other.gameObject.tag == "shield")
        {
            GameObject meteorCollision = Instantiate(_meteorcollision, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            meteorCollision.GetComponent<MeteorExplode>().OnObjectSpawn();

            Destroy(gameObject);
        }
    }
}
