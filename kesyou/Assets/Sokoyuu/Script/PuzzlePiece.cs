using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public Vector2 correctPosition; // 正确的拼图位置（局部坐标）
    public bool isCorrect;          // 检测是否放置正确
    private Vector2 offset;         // 鼠标与拼图块的偏移
    [SerializeField] private float threshold = 50f; // 容差，适当增大适合 UI 元素

    private RectTransform rectTransform;
    private Canvas canvas; // 获取 Canvas，用于正确计算 UI 元素位置

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void SetCorrectPosition(Vector2 pos) // 用于初始化正确位置
    {
        correctPosition = pos;
    }

    void OnMouseDown()
    {
        // 计算鼠标点击时的偏移（使用局部坐标）
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localMousePos
        );
        offset = (Vector2)rectTransform.localPosition - localMousePos;
    }

    void OnMouseDrag()
    {
        // 根据鼠标拖动更新局部坐标
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localMousePos
        );
        rectTransform.localPosition = localMousePos + offset;
    }

    void OnMouseUp()
    {
        // 检测是否接近正确位置
        if (Vector2.Distance(rectTransform.localPosition, correctPosition) < threshold)
        {
            rectTransform.localPosition = correctPosition; // 自动吸附到正确位置
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }
    }
}