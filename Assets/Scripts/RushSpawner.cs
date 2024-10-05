using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RushSpawner : MonoBehaviour
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
        seconds = 0.1f;
        StartCoroutine(Countdown());
        StartCoroutine(CheckForPlayer());
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
            StartCoroutine(meteorRush());
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
        InvokeRepeating("Spawn", 0, seconds);
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
