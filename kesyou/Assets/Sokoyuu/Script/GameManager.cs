using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 引入UI命名空间

public class GameManager : MonoBehaviour
{
    public Button startButton;  // 用于引用开始按钮
    public GameObject puzzleManager; // 引用 PuzzleManager

    void Start()
    {
        // 确保在游戏开始前拼图管理器不激活
        puzzleManager.SetActive(false);

        // 添加按钮点击事件
        startButton.onClick.AddListener(StartGame);
    }

    // 点击开始按钮时启动游戏
    void StartGame()
    {
        // 开始游戏，激活拼图管理器
        puzzleManager.SetActive(true);
        startButton.gameObject.SetActive(false);  // 隐藏开始按钮
    }
}
