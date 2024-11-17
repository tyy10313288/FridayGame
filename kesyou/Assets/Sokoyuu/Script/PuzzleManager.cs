using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<Transform> positions; // 存储拼图块随机位置的列表
    public List<PuzzlePiece> pieces;  // 拼图块对象列表

    void Start()
    {
        ShufflePieces();
    }

    void ShufflePieces()
    {
        // 确保拼图块数量 <= 可用位置数量
        if (pieces.Count > positions.Count)
        {
            Debug.LogError("Error: More pieces than available positions!");
            return;
        }


        // 随机排列拼图块
        foreach (var piece in pieces)
        {
            int randomIndex = Random.Range(0, positions.Count);
            Debug.Log($"Randomly chosen index: {randomIndex}, Position: {positions[randomIndex].position}");
            piece.GetComponent<RectTransform>().localPosition = positions[randomIndex].localPosition; // 适配UI拼图
            positions.RemoveAt(randomIndex); // 移除已用位置，防止重复
        }
    }
}
