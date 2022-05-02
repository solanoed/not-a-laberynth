using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Grid : ScriptableObject
{
    public int width;
    public int height;
    public int m;
    public int cellSize;
    public Cell cellPrefab;
    public Cell endPrefab;
    public Cell objectPrefab;

    public Cell[,] gridArray;
    public PathManager pm;


    public Grid(int width, int height, int cellSize, Cell cellPrefab, Cell endPrefab, Cell objectPrefab, int m)
    {

        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.cellPrefab = cellPrefab;
        this.endPrefab = endPrefab;
        this.objectPrefab = objectPrefab;

        this.m = m;
        // Debug.Log(pm.FindPath(this,width,height,width-1,height-1));
        generateBoard();
    }


    public int[] randomCells()
    {
        HashSet<int> numbers = new HashSet<int>();

        while (numbers.Count < m)
        {
            int r;
            do
            {
                r = Random.Range(0, width * height);
            } while (r == 0 || r == 99);
            numbers.Add(r);
        }
        return obstacle(numbers);
    }
    public int[] obstacle(HashSet<int> rNumb)
    {
        int[] nums = new int[width * height];
        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] = -1;
        }
        for (var i = 0; i < width * height; i++)
        {
            foreach (var item in rNumb)
            {
                if (i == item)
                {
                    nums[i] = item;
                }
            }
        }


        return nums;
    }
    private void print(int[] numb)
    {
        Debug.Log("Hashset");
        foreach (var item in numb)
        {
            Debug.Log(item);
        }
        Debug.Log("End Hashset");
    }

    public void fillBoard(int[] numbers)
    {
        Cell cell;
        gridArray = new Cell[width, height];


        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {

                var p = new Vector2(i, j) * cellSize;
                //Final
                if (i == width - 1 && j == width - 1)
                {

                    cell = Instantiate(endPrefab, p, Quaternion.identity);
                    cell.SetEnd(true);

                }else{
                    cell = Instantiate(cellPrefab, p, Quaternion.identity);
                }
                    
                    //Cell normal 
                    
                //Si es inicio
                if (i == 0 && j == 0)
                {
                    cell.SetStart(true);
                }


                cell.Init(this, (int)p.x, (int)p.y, true, false, false);
                int num = i * 10 + j;
                foreach (var item in numbers)
                {
                    if (num == item)
                    {
                    cell.SetWalkable(false);
                    // cell = Instantiate(objectPrefab, p, Quaternion.identity);
                        

                    }else{

                    }
                }
                gridArray[i, j] = cell;

            }
        }


        var center = new Vector2((float)height / 2 - 0.5f, (float)width / 2 - 0.5f);
        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
    }



    private void generateBoard()
    {
        int[] number = randomCells();
        fillBoard(number);

    }

    internal int GetHeight()
    {
        return height;
    }

    internal int GetWidth()
    {
        return width;
    }


    public void CellMouseClick(Cell cell)
    {
        BoardManager.Instance.CellMouseClick(cell.x, cell.y);
    }



    public Cell GetGridObject(int x, int y)
    {
        return gridArray[x, y];
    }

    internal float GetCellSize()
    {
        return cellSize;
    }
}
