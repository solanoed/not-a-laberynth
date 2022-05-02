using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private GameObject Inner;
    private Grid grid;
    public bool isWalkable;
    public bool isStart;
    public bool isEnd;
    public int x, y ;
    public int gCost, hCost, fCost;
    public Cell pastCell;
    public Sprite objeto;

    public void Init(Grid grid, int x, int y, bool isWalkable,bool isStart,bool isEnd)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = isWalkable;
        this.isStart = isStart;
        this.isEnd = isEnd;
    }

    public Vector2 Position => transform.position;

  

    public void SetSprite(Sprite objeto)
    {
        Inner.GetComponent<SpriteRenderer>().sprite = objeto;
    }

    private void OnMouseDown()
    {
        
        if (Input.GetMouseButton(0))
        {
            grid.CellMouseClick(this);
        } 
    }

    internal void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    internal void SetWalkable(bool v)
    {
        
        isWalkable = v;
        SetSprite(objeto);
    }
    internal void SetStart(bool v)
    {
        isStart = v;
    }
    internal void SetEnd(bool v)
    {
        isEnd = v;
    }

    

}
