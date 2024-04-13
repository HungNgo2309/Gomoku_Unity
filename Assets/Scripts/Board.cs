using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject cellPrefabs;
    public Transform board;
    public GridLayoutGroup gridLayout;
    public int boardSizes;
    public Sprite xSprite;
    public Sprite oSprite;
    public string currentturn = "x";
    private string[,] matrix;

    public void Awake()
    {

    }
    public void Start()
    {
        matrix = new string[boardSizes + 1, boardSizes + 1];
        gridLayout.constraintCount = boardSizes;
        CreateBoard();

    }
    private void CreateBoard()
    {
        for(int i=1;i<=boardSizes;i++)
        {
            for(int j=1;j<=boardSizes;j++)
            {
                GameObject cellTransform= Instantiate(cellPrefabs, board);
                Cell cell = cellTransform.GetComponent<Cell>();
                cell.row = i;
                cell.column = j;
                matrix[i, j] = "";
            }
        }
    }
    public bool Check(int row, int column)
    {
        matrix[row, column] = currentturn;
        bool result = false;
        int count = 0;
        for(int i=row-1;i>=1;i--)
        {
            if(matrix[i,column]==currentturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = row + 1; i <= boardSizes; i++)
        {
            if (matrix[i, column] == currentturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if(count+1>=5)
        {
            result = true;
        }
        count = 0;
        for (int i = column - 1; i >= 1; i--)
        {
            if (matrix[row, i] == currentturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = column + 1; i <= boardSizes; i++)
        {
            if (matrix[row, i] == currentturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            result = true;
        }
        count = 0;
        ///cheo
        for (int i = column - 1; i >= 1; i--)
        {
            if (matrix[row-(column-i), i] == currentturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = column + 1; i <= boardSizes; i++)
        {
            if (matrix[row + (column - i), i] == currentturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            result = true;
        }
        ///cheo 2
        count = 0;
        for (int i = column + 1; i <= boardSizes; i++)
        {
            if (matrix[row - (column - i), i] == currentturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = column - 1; i >=1; i--)
        {
            if (matrix[row + (column - i), i] == currentturn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            result = true;
        }
        return result;
    }
}
