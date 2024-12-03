using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 8;             // 网格行数
    public int cols = 8;             // 网格列数
    public int elementTypes = 5;     // 元素种类数量
    public GameObject[] elementPrefabs; // 元素预制体数组
    public Transform gridParent;    // 元素的父对象

    private int[,] grid;             // 存储网格数据

    void Start()
    {
        InitializeGrid();
        CreateGridVisuals();
    }

    void InitializeGrid()
    {
        grid = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                do
                {
                    grid[row, col] = Random.Range(0, elementTypes); // 随机生成
                }
                while (HasInitialMatch(row, col)); // 避免初始匹配
            }
        }
    }

    bool HasInitialMatch(int row, int col)
    {
        if (col >= 2 && grid[row, col] == grid[row, col - 1] && grid[row, col] == grid[row, col - 2])
        {
            return true;
        }
        if (row >= 2 && grid[row, col] == grid[row - 1, col] && grid[row, col] == grid[row - 2, col])
        {
            return true;
        }
        return false;
    }

    void CreateGridVisuals()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int elementType = grid[row, col];
                GameObject element = Instantiate(elementPrefabs[elementType], gridParent);
                element.transform.position = new Vector2(col, -row);
            }
        }
    }
}