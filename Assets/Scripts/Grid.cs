using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Grid : ScriptableObject
{
    private int width;
    private int height;
    private int m;
    private int cellSize;
    private Cell cellPrefab;
    private Cell endPrefab;
    private Cell[,] gridArray;


    public Grid(int width, int height, int cellSize, Cell cellPrefab,Cell endPrefab, int m)
    {

        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.cellPrefab = cellPrefab;
        this.endPrefab = endPrefab;
        this.m = m;

        generateBoard();
    }
    public int[] randomCells()
    {
        HashSet<int> numbers = new HashSet<int>();
        
        while (numbers.Count < m )
        {
            int r;
            do
            {
                r=Random.Range(0, width * height);
            } while (r ==0 || r ==99 );
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
        // print(nums);


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
        // int [] number = randomCells();


        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                var p = new Vector2(i, j) * cellSize;
                if(i == width-1 && j == width-1){

                cell = Instantiate(endPrefab, p, Quaternion.identity);
                cell.SetEnd(true);

                }else{
                cell = Instantiate(cellPrefab, p, Quaternion.identity);

                }
                
                if (i == 0 && j == 0)
                {
                    // cell.Init(this, (int)p.x, (int)p.y, true, false, true);
                    cell.SetStart(true);
                }
                cell.Init(this, (int)p.x, (int)p.y, true, false, false);
                int num = i * 10 + j;
                foreach (var item in numbers)
                {
                    if (num == item)
                    {
                        cell.SetWalkable(false);

                    }
                }
                gridArray[i, j] = cell;

            }
        }


        // for (var i = 0; i < width; i++)
        // {
        //     for (var j = 0; j < height; j++)
        //     {
        //         var p = new Vector2(i, j) * cellSize;
        //         cell = Instantiate(cellPrefab, p, Quaternion.identity);
        //         cell.Init(this, (int)p.x, (int)p.y, true, false, false);
        //         int num = j + i*10;
        //         Debug.Log("num: "+num+" numbers: "+numbers[j]);
        //         if(num==numbers[cont]){
        //                 cell.SetWalkable(false);
        //         }else{
        //                 cell.SetColor(Color.blue);
        //         }
        //         cell.SetColor(Color.blue);
        //         gridArray[i, j] = cell;

        //     }
        //     cont++;
        // }
        var center = new Vector2((float)height / 2 - 0.5f, (float)width / 2 - 0.5f);
        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
    }



    private void generateBoard()
    {
        int[] number = randomCells();
        fillBoard(number);
        // Cell cell;
        // gridArray = new Cell[width, height];
        // // int nw = 1;
        // // print(number);

        // for (int i = 0; i < width; i++)
        // {
        //     for (int j = 0; j < height; j++)
        //     {
        //         var p = new Vector2(i, j) * cellSize;
        //         cell = Instantiate(cellPrefab, p, Quaternion.identity);
        //         cell.Init(this, (int)p.x, (int)p.y, true, false, false);
        //         int num = j + i*10;


        //             Debug.Log("numero: "+num);
        //             Debug.Log("number: "+number[i]);
        //             if (num==number[i])
        //             {
        //                 Debug.Log("Item: "+number[i]+"Matrix: "+num);
        //                 cell.SetWalkable(false);

        //             }else{
        //                 // Debug.Log(num+" walkable");
        //                 cell.SetColor(Color.blue);
        //             }


        //         // double rndm = Random.Range(1, 7);

        //         // if ((rndm == 3) && nw < m)
        //         // {
        //         //     nw++;
        //         //     cell.SetWalkable(false);


        //         // }
        //         // else
        //         // {
        //         //     cell.SetColor(Color.blue);

        //         // }
        //         // // Debug.Log("x: "+width + ", y: "+height);
        //         gridArray[i, j] = cell;
        //     }
        // }
        // // Debug.Log("Celdas obstáculo: " + nw);

        // var center = new Vector2((float)height / 2 - 0.5f, (float)width / 2 - 0.5f);

        // Camera.main.transform.position = new Vector3(center.x, center.y, -5);
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
        //cell.SetText("Click on cell "+cell.x+ " "+ cell.y);
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
