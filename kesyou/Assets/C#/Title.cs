    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void _Start()
    {
        //イベントの値をリセットし、ゲーム開始
        PlayerPrefs.SetInt("EVENT", 0);
        SceneManager.LoadScene("Text");    
    }
}
