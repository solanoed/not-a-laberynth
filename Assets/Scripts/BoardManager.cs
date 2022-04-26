using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Cell endPrefab;
    [SerializeField] private Player PlayerPrefab;
    private Grid grid;
    private Player player;
    [SerializeField]
    private float moveSpeed = 2f;
    public int n = 10;
    public int m = 10;
    //Level collider
    public int iLevelToLoad;
    public string sLevelToLoad;
    int currentLevel;

    public bool useIntegerToLoadLevel = false;

    private void Awake()
    {
        Instance = this;
        currentLevel = PlayerPrefs.GetInt("Level");

    }

    private void Start()
    {
        Debug.Log("Nivel: " + currentLevel);
        switch (currentLevel)
        {
            case 0:
                grid = new Grid(n, n, 1, CellPrefab, endPrefab, m);
                player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);
                break;
            case 1:
                grid = new Grid(n, n, 1, CellPrefab, endPrefab, m);
                player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);

                break;
            default:
                break;
        }

        
    }
    void Update()
    {
        if (player.GetPosition.x == n - 1 && player.GetPosition.y == n - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("Level", currentLevel++);
            Debug.Log("LLegó al final");
        }
        // if(player.GetPosition.x==0 && player.GetPosition.y==0){
        //     Debug.Log("Inicio");
        // }
    }
    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);


        player.SetPath(path);
    }

}
