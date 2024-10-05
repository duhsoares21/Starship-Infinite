using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour, IPooledObject
{
    public float speed; 
    public bool canBeDestroyed = false;

    public void OnObjectSpawn()
    {
        speed = Random.Range(-30, -50);
        
        float scaleX = Random.Range(0.8f, 1.6f);
        float scaleY = Random.Range(0.8f, 1.6f);
        float scaleZ = Random.Range(0.8f, 1.6f);

        float torque = Random.Range(5, 15);

        GetComponent<Transform>().localScale = new Vector3(scaleX, scaleY, scaleZ);
        GetComponent<ConstantForce>().torque = new Vector3(torque, torque, torque);
        GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
    }


    void Update()
    {
        if(GetComponent<Transform>().localPosition.y <= -10.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
