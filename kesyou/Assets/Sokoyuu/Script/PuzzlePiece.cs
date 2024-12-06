using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public Vector2 correctPosition; // 正确的拼图位置
    public bool isCorrect;          // 检测是否放置正确
    private Vector2 offset;         // �����ƴͼ���ƫ��
    [SerializeField] private float threshold = 50f; // 偏移吸附距离

    private PuzzleManager puzzleManager; // 引用 PuzzleManager

    void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    public void SetCorrectPosition(Vector2 pos)
    {
        correctPosition = pos;
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3)offset;
        transform.position = new Vector3(newPos.x, newPos.y, 0);
    }

    private void OnMouseUp()
    {
        if (Vector2.Distance(transform.localPosition, correctPosition) < threshold)
        {
            transform.localPosition = correctPosition;
            isCorrect = true;
            puzzleManager.CheckGameStatus(); // 通知 PuzzleManager 检查状态
        }
        else
        {
            isCorrect = false;
        }
    }
}
