using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryController : MonoBehaviour
{
    public GameObject panel;
    public Button startButton;
    public Text startText;
    public GameObject[] gameObjectsToActivate;

    public MemoryVer2 memoryGame;

    void Start()
    {
        panel.SetActive(true);
        startButton.onClick.AddListener(StartGame);
        startText.gameObject.SetActive(false);  
        foreach (var obj in gameObjectsToActivate)
        {
            obj.SetActive(false);
        }
    }

    void StartGame()
    {
        panel.SetActive(false);
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        startText.gameObject.SetActive(true);

        startText.text = "Ready";
        yield return new WaitForSeconds(1.5f);

        startText.text = "Start!";
        yield return new WaitForSeconds(1.0f);

        startText.gameObject.SetActive(false);

        foreach (var obj in gameObjectsToActivate)
        {
            obj.SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);

        memoryGame.GenerateRanColor();
        memoryGame.StartGame(); 
    }        
}
