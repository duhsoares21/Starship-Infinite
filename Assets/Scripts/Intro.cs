using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroGame());
    }

    IEnumerator IntroGame()
    {
        yield return new WaitForSeconds(4.5f);
        GameObject.Find("agame").GetComponent<Animator>().enabled = true;
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadSceneAsync("StartScreen");
    }
}
