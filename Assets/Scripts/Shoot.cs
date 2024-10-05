using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject BulletBaseL, BulletBaseR;
    private bool canShootR = true;
    private bool canShootL = true;

    [SerializeField]
    //private ObjectPooling bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootCoolDown",0,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("RT") != 0 && canShootR)
        {           
            GameObject bullR = Instantiate(bullet, BulletBaseR.GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            bullR.GetComponent<Bullet>().OnObjectSpawn();

            if(bullR != null)
            {
                //BulletBaseR.GetComponent<AudioSource>().Play();
                canShootR = false;
            }
        }
        
        if(Input.GetAxis("LT") != 0 && canShootL)
        {
            GameObject bullL = Instantiate(bullet, BulletBaseR.GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            bullL.GetComponent<Bullet>().OnObjectSpawn();

            if (bullL != null)
            {
                //BulletBaseL.GetComponent<AudioSource>().Play();
                canShootL = false;
            }
        }       
    }

    void ShootCoolDown()
    {
        if(!canShootL)
        {
            canShootL = true;
        }

        if(!canShootR)
        {
            canShootR = true;
        }
    }
}

