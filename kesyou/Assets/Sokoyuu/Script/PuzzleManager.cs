using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 引入场景管理命名空间

public class PuzzleManager : MonoBehaviour
{
    public List<Transform> positions; // 存储拼图块随机位置的列表
    public List<PuzzlePiece> pieces;  // 拼图块对象列表

    public Text countdownText;       // 倒计时文本
    public GameObject startButton;   // 开始按钮
    public GameObject puzzleContainer; // 拼图块父对象，用于隐藏拼图

    private float countdownTime = 30f; // 倒计时总时间
    private bool isGameStarted = false;

    void Start()
    {
        // 隐藏拼图块和倒计时
        foreach (var piece in pieces)
        {
            piece.gameObject.SetActive(false);
        }
        countdownText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        // 点击开始按钮触发游戏逻辑
        startButton.SetActive(false); // 隐藏开始按钮
        foreach (var piece in pieces)
        {
            piece.gameObject.SetActive(true); // 显示拼图块
        }
        countdownText.gameObject.SetActive(true); // 显示倒计时
        isGameStarted = true;
        ShufflePieces(); // 打乱拼图
    }

    void ShufflePieces()
    {
        // 随机排列拼图块位置
        List<Transform> availablePositions = new List<Transform>(positions);
        foreach (var piece in pieces)
        {
            int randomIndex = Random.Range(0, availablePositions.Count);
            piece.GetComponent<RectTransform>().localPosition = availablePositions[randomIndex].localPosition;
            availablePositions.RemoveAt(randomIndex); // 移除已用位置
        }
    }

    void Update()
    {
        if (isGameStarted)
        {
            UpdateCountdown();
        }
    }

    void UpdateCountdown()
    {
        // 倒计时逻辑
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            countdownText.text = "Time: " + Mathf.CeilToInt(countdownTime).ToString();
        }
        else
        {
            EndGame(false); // 时间结束，游戏失败
        }
    }

    void EndGame(bool isWin)
    {
        isGameStarted = false; // 停止倒计时

        // 隐藏拼图块
        puzzleContainer.SetActive(false);

        if (isWin)
        {
            SceneManager.LoadScene("bunki"); // 跳转到胜利场景
        }
        else
        {
            SceneManager.LoadScene("GameOver"); // 跳转到失败场景
        }

        // 停止所有拼图块的交互
        foreach (var piece in pieces)
        {
            piece.enabled = false;
        }
    }

    public void CheckGameStatus()
    {
        // 检查是否所有拼图块都已放置正确
        foreach (var piece in pieces)
        {
            if (!piece.isCorrect)
            {
                return; // 仍有拼图未正确放置
            }
        }

        // 全部正确，游戏胜利
        EndGame(true);
    }
}