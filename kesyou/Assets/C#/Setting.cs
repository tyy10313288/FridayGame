using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Setting : MonoBehaviour, IPointerClickHandler
{
    public GameObject settingsscreen;
    public bool _setting;
    void Start()
    {
        //ゲーム開始時に設定画面を非表示
        settingsscreen.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //設定のアイコンが押されたら設定画面を表示
        settingsscreen.SetActive(true);
        //設定画面が開かれているときは化粧を押せないようにする
        _setting = true;
    }
}
