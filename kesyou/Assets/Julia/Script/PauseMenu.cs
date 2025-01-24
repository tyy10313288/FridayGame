using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject SettingPanel;
    
    public Button SettingButton;
    public Button ResumeButton;
    public Button TitleButton;
    public Button QuitButton;
    public bool GameIsPaused = false;

    void Start()
    {        
        SettingPanel.SetActive(false);        
    }
    void Update()
    {
        SettingButton.onClick.AddListener(Pause);
    }  

    public void Pause()
    {
        SettingPanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        SettingPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
    public void Quit()
    {
        Application.Quit();
    }
   
}
