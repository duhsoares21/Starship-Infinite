using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplode : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        GetComponent<ParticleSystem>().Stop();
        GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().Play();

        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponentInChildren<ParticleSystem>().Play();
    }   
}
