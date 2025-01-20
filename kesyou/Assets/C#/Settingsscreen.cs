using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Settingsscreen : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] string screen;
    public GameObject settingsscreen;
    Setting setting;
    void Start()
    {
        setting = GameObject.Find("Setting").GetComponent<Setting>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (screen == "タイトルに戻る")
            SceneManager.LoadScene("Title");

        if (screen == "ゲーム終了")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }

        if (screen == "戻る")
        {
            setting._setting = false;
            settingsscreen.SetActive(false);
        }

    }
}
