using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryController : MonoBehaviour
{
    public GameObject panel;  // 游戏开始时的UI面板
    public Button startButton;  // 开始按钮
    public Text startText;  // 显示 "Ready" 和 "Start!" 的文字
    public GameObject[] gameObjectsToActivate;  // 游戏开始后需要激活的对象

    public MemoryGame memoryGame;  // 引用 MemoryGame 脚本

    void Start()
    {
        panel.SetActive(true);
        startButton.onClick.AddListener(StartGame);
        startText.gameObject.SetActive(false);  
        foreach (var obj in gameObjectsToActivate)
        {
            obj.SetActive(false);  // 初始化时禁用所有游戏对象
        }
    }

    void StartGame()
    {
        panel.SetActive(false);  // 隐藏开始面板
        StartCoroutine(StartCountdown());  // 开始倒计时
    }

    IEnumerator StartCountdown()
    {
        startText.gameObject.SetActive(true);

        startText.text = "Ready";
        yield return new WaitForSeconds(1.5f);

        startText.text = "Start!";
        yield return new WaitForSeconds(1.0f);

        startText.gameObject.SetActive(false);

        foreach (var obj in gameObjectsToActivate)
        {
            obj.SetActive(true);  // 激活所有游戏对象
        }

        yield return new WaitForSeconds(0.5f);  // 确保激活后再开始游戏

        memoryGame.SelectRandomColors();  // 选择随机颜色
        memoryGame.StartGame();  // 开始显示颜色序列
    }        
}
