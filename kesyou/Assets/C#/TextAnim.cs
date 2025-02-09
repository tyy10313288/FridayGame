using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextAnim : MonoBehaviour
{
    void Start()
    {
        //アニメーションの再生終わりにシーン切り替え
        Invoke("Change", 2);
    }
    private void Change()
    {
        SceneManager.LoadScene("bunki");  
    }
}
