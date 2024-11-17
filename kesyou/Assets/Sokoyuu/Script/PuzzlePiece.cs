using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public Vector2 correctPosition; // ��ȷ��ƴͼλ�ã��ֲ����꣩
    public bool isCorrect;          // ����Ƿ������ȷ
    private Vector2 offset;         // �����ƴͼ���ƫ��
    [SerializeField] private float threshold = 50f; // �ݲ�ʵ������ʺ� UI Ԫ��

    private RectTransform rectTransform;
    private Canvas canvas; // ��ȡ Canvas��������ȷ���� UI Ԫ��λ��

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void SetCorrectPosition(Vector2 pos) // ���ڳ�ʼ����ȷλ��
    {
        correctPosition = pos;
    }

    void OnMouseDown()
    {
        // ���������ʱ��ƫ�ƣ�ʹ�þֲ����꣩
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
        // ��������϶����¾ֲ�����
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
        // ����Ƿ�ӽ���ȷλ��
        if (Vector2.Distance(rectTransform.localPosition, correctPosition) < threshold)
        {
            rectTransform.localPosition = correctPosition; // �Զ���������ȷλ��
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }
    }
}