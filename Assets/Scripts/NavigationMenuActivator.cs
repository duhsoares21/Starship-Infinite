using UnityEngine;

public class NavigationMenuActivator : MonoBehaviour
{
    public void ActivateMenu()
    {
        GameStatsManager GSM = GameObject.Find("GameStats").GetComponent<GameStatsManager>();
        int inputIndex = GSM.GetMainInput();
        GameObject.Find("UISelector").GetComponent<Transform>().GetChild(inputIndex).gameObject.SetActive(true);
    }
}
