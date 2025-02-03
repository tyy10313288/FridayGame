using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Settingsscreen : MonoBehaviour
{
    public GameObject settingsscreen;
    Setting setting;
    void Start()
    {
        setting = GameObject.Find("Setting").GetComponent<Setting>();
    }
    
    public void Back()
    {
        setting._setting = false;
        settingsscreen.SetActive(false);
    }
    public void BackTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
