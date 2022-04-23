using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Player PlayerPrefab;
    private Grid grid;
    private Player player;
    [SerializeField]
    private float moveSpeed = 2f;
    public int n = 10;
    public int m = 10;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        grid = new Grid(n, n, 1, CellPrefab,m);

        player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);  
    }

    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);

        player.SetPath(path);
    }

}
