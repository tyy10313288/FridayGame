using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] string screen;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (screen == "もう一度挑戦する")
        {
            PlayerPrefs.SetInt("EVENT", 0);
            SceneManager.LoadScene("bunki");
        }
        if (screen == "タイトルに戻る")
            SceneManager.LoadScene("Title");

        if (screen == "ゲーム終わり")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }
    }
}
