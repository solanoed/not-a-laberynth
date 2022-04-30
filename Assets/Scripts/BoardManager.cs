using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;


public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Cell endPrefab;
    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private Enemy EnemyPrefab;
     public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    private Grid grid;
    private Player player;
    private Enemy e1, e2, e3, e4;
    [SerializeField]
    private float moveSpeed = 2f;
    public int n = 10;
    public int m = 10;
    //Level collider
    public GameManager manager;
    public Text LevelName;
    public Text time;

    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    


    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        LevelName.text = "Level 1";
        grid = new Grid(n, n, 1, CellPrefab, endPrefab, m);
        player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);
        e1 = Instantiate(EnemyPrefab, new Vector2(0, n - 1), Quaternion.identity);
        
        switch (manager.Level)
        {
            case 1:
                InvokeRepeating("enemyMove", 0f, 2f);
                break;
            case 2:
                
                break;
            case 3:
                break;
            case 4:
                break;
        }

        

        // e2 = Instantiate(EnemyPrefab, new Vector2(n - 1,0), Quaternion.identity);
        // e3 = Instantiate(EnemyPrefab, new Vector2(0, n - 3), Quaternion.identity);
        // e4 = Instantiate(EnemyPrefab, new Vector2(n - 3,0), Quaternion.identity);


    }

    void move(int x, int y){
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);
        player.SetPath(path);
    }
    void enemyMove(){
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)e1.GetPosition.x, (int)e1.GetPosition.y, (int)player.GetPosition.x, (int)player.GetPosition.y);
        e1.SetPath(path);
        e1.Move();
    }
    void Update()

    {

        if (Input.GetKeyDown(up))
        {
            move((int)player.GetPosition.x,(int)player.GetPosition.y+1);
        }else
        if (Input.GetKeyDown(down))
        {
            move((int)player.GetPosition.x,(int)player.GetPosition.y-1);

        }
        if (Input.GetKeyDown(left)==true)
        {
            move((int)player.GetPosition.x-1,(int)player.GetPosition.y);
        }
        if (Input.GetKeyDown(right))
        {
            move((int)player.GetPosition.x+1,(int)player.GetPosition.y);

        }
        // horizontalMove = Input.GetKeyDown(up);
        // verticalMove = Input.GetAxisRaw("Vertical");
        // Debug.Log(horizontalMove+" "+verticalMove);
        PlayerPrefs.SetString("Time", time.text);
        PlayerPrefs.SetString("Level", LevelName.text);
        
        if (player.GetPosition.x == n - 1 && player.GetPosition.y == n - 1)
        {
            switch (manager.Level)
            {
                case 1:
                    Debug.Log("Level 1 To Level 2");
                    LevelName.text = "Level 2";
                    player.ResetPosition();
                    e1.ResetPosition(0, n - 1);
                    e2 = Instantiate(EnemyPrefab, new Vector2(n-1, 0), Quaternion.identity);
                    
                    manager.nextLevel();
                    break;
                case 2:
                    LevelName.text = "Level 3";
                    player.ResetPosition();
                    e1 = Instantiate(EnemyPrefab, new Vector2(0, n - 1), Quaternion.identity);
                    e2 = Instantiate(EnemyPrefab, new Vector2(n-1, 0), Quaternion.identity);
                    e3 = Instantiate(EnemyPrefab, new Vector2(0, n - 3), Quaternion.identity);
                    
                    manager.nextLevel();
                    SceneManager.LoadScene(2);

                    break;
                case 3:
                    LevelName.text = "Level 4";
                    player.ResetPosition();
                    Destroy(e1);
                    Destroy(e2);
                    Destroy(e3);
                    e1 = Instantiate(EnemyPrefab, new Vector2(0, n - 1), Quaternion.identity);
                    e2 = Instantiate(EnemyPrefab, new Vector2(n-1, 0), Quaternion.identity);
                    e3 = Instantiate(EnemyPrefab, new Vector2(0, n - 3), Quaternion.identity);
                    e4 = Instantiate(EnemyPrefab, new Vector2(n - 3,0), Quaternion.identity);
                    manager.nextLevel();
                    SceneManager.LoadScene(2);
                    break;
                case 4:
                    break;
            }

            Debug.Log(manager.Level);
        }
    }


    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);
        player.SetPath(path);
    }

}
