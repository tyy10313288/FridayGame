using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    //public GameObject SettingPanel;

    public Button startButton;
    // public Button SettingButton;
    // public Button ResumeButton;
    // public Button TitleButton;
    // public Button QuitButton;
    

    public CountDownTimer timerScript;
    public Text startText;
    public GameObject[] gameObjectsToActivate;

    //public static bool GameIsPaused = false;

    void Start()
    {
        panel.SetActive(true);
        //SettingPanel.SetActive(false);
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
        //SettingButton.onClick.AddListener(Pause);
    }

    void StartGame()
    {
        panel.SetActive(false);
        StartCoroutine(StartCountdown());
    }

    // void Pause()
    // {
    //     SettingPanel.SetActive(true);
    //     Time.timeScale = 0f;
    //     GameIsPaused = true;
    // }
    // void Resume()
    // {
    //     SettingPanel.SetActive(false);
    //     Time.timeScale = 1f;
    //     GameIsPaused = false;
    // }
    // void Title()
    // {
    //     SceneManager.LoadScene("Title");
    // }
    // void Quit()
    // {
    //     Application.Quit();
    // }

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
