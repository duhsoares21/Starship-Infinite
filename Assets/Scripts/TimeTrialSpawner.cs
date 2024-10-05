using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialSpawner : MonoBehaviour
{
    private float minX = -31.5f;
    private float maxX =  31.5f;
    private float minY =  85;
    private float maxY =  100;

    public int time;
    public float seconds;
    public string[] tags;
    public bool canChangeSpawn;

    ObjectPooler objectPooler;

    public void Start()
    {
        canChangeSpawn = true;
        objectPooler = ObjectPooler.Instance;
        time = 0;
        seconds = 0.25f;
        //StartSpawn();
    }

    public void StartSpawn() {
        InvokeRepeating("Spawn", 0, seconds);
    }

    void FixedUpdate()
    {
        time = Mathf.RoundToInt(Time.timeSinceLevelLoad);

        if(time > 0 && time % 60 == 0)
        {
            if (seconds > 0.1f)
            {
                if (canChangeSpawn)
                {
                    seconds = seconds - 0.1f;
                }

                canChangeSpawn = false;
            }
            else
            {
                seconds = 0.1f;
            }

            CancelInvoke("Spawn");
            InvokeRepeating("Spawn", 0, seconds);
            StartCoroutine("meteorRush");
        }
    }

    IEnumerator meteorRush()
    {
        //GameObject.Find("RUSH").GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(3f);
        //GameObject.Find("RUSH").GetComponent<Text>().enabled = false;
        canChangeSpawn = true;
    }

    void Spawn(){
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        string tag = tags[Random.Range(0, tags.Length)];

        objectPooler.SpawnFromPool(tag, new Vector3(x, y, 0), Random.rotation);
    }
}
