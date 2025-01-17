using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    public GameObject SettingPanel;

    public Button startButton;
    public Button SettingButton;

    public CountDownTimer timerScript;
    public Text startText;
    public GameObject[] gameObjectsToActivate;

    void Start()
    {
        panel.SetActive(true);
        SettingPanel.SetActive(false);
        startButton.onClick.AddListener(StartGame);
        startText.gameObject.SetActive(false);      
        foreach (var obj in gameObjectsToActivate)
        {
            obj.SetActive(false);
        }
        timerScript.enabled = false;
    }
    void Update()
    {
        SettingButton.onClick.AddListener(Setting);
    }

    void StartGame()
    {
        panel.SetActive(false);
        StartCoroutine(StartCountdown());
    }

    void Setting()
    {
        SettingPanel.SetActive(true);
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

        
        timerScript.enabled = true;
        timerScript.BeginCountdown();
    }
}
