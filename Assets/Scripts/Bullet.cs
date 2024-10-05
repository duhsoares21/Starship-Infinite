using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        Vector3 force = new Vector3(0, 70, 0);
        GetComponent<Rigidbody>().velocity = force;
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
