using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // ����UI�����ռ�

public class GameManager : MonoBehaviour
{
    public Button startButton;  // �������ÿ�ʼ��ť
    public GameObject puzzleManager; // ���� PuzzleManager

    void Start()
    {
        // ȷ������Ϸ��ʼǰƴͼ������������
        puzzleManager.SetActive(false);

        // ��Ӱ�ť����¼�
        startButton.onClick.AddListener(StartGame);
    }

    // �����ʼ��ťʱ������Ϸ
    void StartGame()
    {
        // ��ʼ��Ϸ������ƴͼ������
        puzzleManager.SetActive(true);
        startButton.gameObject.SetActive(false);  // ���ؿ�ʼ��ť
    }
}
