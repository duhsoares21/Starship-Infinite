using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusic : MonoBehaviour
{
    public AudioClip bgm;
    public AudioClip menuMusic;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Audio").GetComponent<AudioSource>().clip = bgm;
        GameObject.Find("Audio").GetComponent<AudioSource>().pitch = 1.0f;
        GameObject.Find("Audio").GetComponent<AudioSource>().volume = 0.07f;
        GameObject.Find("Audio").GetComponent<AudioSource>().Play();
    }

    public void SetMenuMusic()
    {
        GameObject.Find("Audio").GetComponent<AudioSource>().clip = menuMusic;
        GameObject.Find("Audio").GetComponent<AudioSource>().pitch = 1.0f;
        GameObject.Find("Audio").GetComponent<AudioSource>().volume = 0.1f;

        GameObject.Find("Audio").GetComponent<AudioSource>().Play();
    }
}
