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
        if (screen == "������x���킷��")
        {
            PlayerPrefs.SetInt("EVENT", 0);
            SceneManager.LoadScene("bunki");
        }
        if (screen == "�^�C�g���ɖ߂�")
            SceneManager.LoadScene("Title");

        if (screen == "�Q�[���I���")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }
    }
}
