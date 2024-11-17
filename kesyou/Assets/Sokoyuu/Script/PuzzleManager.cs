using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<Transform> positions; // �洢ƴͼ�����λ�õ��б�
    public List<PuzzlePiece> pieces;  // ƴͼ������б�

    void Start()
    {
        ShufflePieces();
    }

    void ShufflePieces()
    {
        // ȷ��ƴͼ������ <= ����λ������
        if (pieces.Count > positions.Count)
        {
            Debug.LogError("Error: More pieces than available positions!");
            return;
        }


        // �������ƴͼ��
        foreach (var piece in pieces)
        {
            int randomIndex = Random.Range(0, positions.Count);
            Debug.Log($"Randomly chosen index: {randomIndex}, Position: {positions[randomIndex].position}");
            piece.GetComponent<RectTransform>().localPosition = positions[randomIndex].localPosition; // ����UIƴͼ
            positions.RemoveAt(randomIndex); // �Ƴ�����λ�ã���ֹ�ظ�
        }
    }
}
