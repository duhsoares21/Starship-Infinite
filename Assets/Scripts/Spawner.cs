using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    private float minX = -31.5f;
    private float maxX =  31.5f;
    private float minY =  85;
    private float maxY =  100;

    public int time;
    public float seconds;
    public GameObject[] tags;
    public bool canChangeSpawn;
    private int secondsToGo = 3;

    public void Start()
    {
        canChangeSpawn = true;
        time = 0;
        seconds = 0.4f;
        StartCoroutine(Countdown());
        StartCoroutine(CheckForPlayer());
        StartCoroutine("timePlayed");
    }

    IEnumerator Countdown(){
        GameObject.Find("Contador").GetComponent<Text>().text = secondsToGo.ToString();
        yield return new WaitForSeconds(1f);
        if(secondsToGo > 1)
        {
            secondsToGo--;
            StartCoroutine(Countdown());
        }
        else
        {
            GameObject.Find("Contador").GetComponent<Text>().text = "";
        }
    }

    IEnumerator CheckForPlayer(){
        int totalPlayers = GameObject.Find("InputController").GetComponent<PlayerInputManager>().playerCount;
        if(totalPlayers > 0)
        {
            StopCoroutine(CheckForPlayer());
            yield return new WaitForSeconds(3f);
            StartSpawn();
        }
        else
        {
            StartCoroutine(CheckForPlayer());
        }
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

    IEnumerator timePlayed()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetTimePlayedInGame();
        StartCoroutine("timePlayed");
    }

    IEnumerator meteorRush()
    {
        GameObject.Find("MeteorRush").GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(3f);
        GameObject.Find("MeteorRush").GetComponent<Text>().enabled = false;
        canChangeSpawn = true;
    }

    void Spawn(){
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        GameObject tag = tags[Random.Range(0, tags.Length)];

        GameObject meteor = Instantiate(tag, new Vector3(x, y, 15), Random.rotation);
        meteor.GetComponent<Meteor>().OnObjectSpawn();

    }
}
