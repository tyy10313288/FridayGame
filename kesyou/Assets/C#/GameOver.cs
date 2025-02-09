using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //イベントの値を0にしてリスタート
    public void Retry()
    {
        PlayerPrefs.SetInt("EVENT", 0);
        SceneManager.LoadScene("bunki");
    }
    //タイトルに戻る
    public void BackTitle()
    {
        SceneManager.LoadScene("Title");
    }
    //ゲーム終了
    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
