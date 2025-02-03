using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        PlayerPrefs.SetInt("EVENT", 0);
        SceneManager.LoadScene("bunki");
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
