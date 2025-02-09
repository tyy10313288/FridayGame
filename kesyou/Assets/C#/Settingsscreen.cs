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
        //別スクリプトの取得
        setting = GameObject.Find("Setting").GetComponent<Setting>();
    }
    
    public void Back()
    {
        //戻るボタンが押されたら設定画面を非表示にし、化粧を押せるようにする
        setting._setting = false;
        settingsscreen.SetActive(false);
    }
    public void BackTitle()
    {
        //タイトルに戻る
        SceneManager.LoadScene("Title");
    }
    public void GameEnd()
    {
        //ゲーム終了
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
