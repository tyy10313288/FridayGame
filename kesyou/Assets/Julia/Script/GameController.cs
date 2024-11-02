using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    public Button startButton;
    public CountDownTimer timerScript;
    public Text startText;
    public GameObject[] gameObjectsToActivate;

    void Start()
    {
        panel.SetActive(true);
        startButton.onClick.AddListener(StartGame);
        startText.gameObject.SetActive(false);  
        foreach (var obj in gameObjectsToActivate)
        {
            obj.SetActive(false);  // 初始禁用所有要激活的游戏对象
        }
        timerScript.enabled = false;  // 初始禁用计时器
    }

    void StartGame()
    {
        panel.SetActive(false);
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        startText.gameObject.SetActive(true);

        startText.text = "Ready";
        yield return new WaitForSeconds(1.5f);  // 等待1.5秒

        startText.text = "Start!";
        yield return new WaitForSeconds(1.0f);  // 再等待1.0秒

        startText.gameObject.SetActive(false);  // 隐藏文本

        // 激活所有游戏对象
        foreach (var obj in gameObjectsToActivate)
        {
            obj.SetActive(true);
        }

        // 启动计时器
        timerScript.enabled = true;
        timerScript.BeginCountdown();
    }
}
