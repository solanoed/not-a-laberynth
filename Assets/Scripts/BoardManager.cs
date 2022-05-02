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
    [SerializeField] private Cell objectPrefab;
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
  
    //Level collider
    public GameManager manager;
    public Text LevelName;
    public Text time;

    int n = 10;
    int m = 10;

    public float horizontalMove = 0f;
    public float verticalMove = 0f;



    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        LevelName.text = "Level 1";
        PlayerPrefs.SetString("Status", "None");
        n = PlayerPrefs.GetInt("n");
        m = PlayerPrefs.GetInt("m");



        grid = new Grid(n, n, 1, CellPrefab, endPrefab,objectPrefab, m);
        player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);
        e1 = Instantiate(EnemyPrefab, new Vector2(0, n - 1), Quaternion.identity);
        InvokeRepeating("enemyMove", 0f, 1f);


    }

    void move(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);
        player.SetPath(path);
    }
    void enemyMove()
    {
        switch (manager.Level)
        {

            case 1:
                followE1();
                break;
            case 2:
                followE1();
                followE2();
                break;
            case 3:
                followE1();
                followE2();
                followE3();
                break;
            case 4:
                followE1();
                followE2();
                followE3();
                followE4();
                break;

        }
    }
    void followE1()
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)e1.GetPosition.x, (int)e1.GetPosition.y, (int)player.GetPosition.x, (int)player.GetPosition.y);
        e1.SetPath(path);
        e1.setSpeed(6f);
        e1.Move();
        InvokeRepeating("col1", 0f, 0.02f);

        
        
    }
    void col1(){
        if (player.GetPosition.x == e1.GetPosition.x && player.GetPosition.y == e1.GetPosition.y)
        {
            SceneManager.LoadScene(2);
            PlayerPrefs.SetString("Status", "Lose");
        }
    }
    void followE2()
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)e2.GetPosition.x, (int)e2.GetPosition.y, (int)player.GetPosition.x, (int)player.GetPosition.y);
        e2.SetPath(path);
        e2.setSpeed(6f);
        e2.Move();
        InvokeRepeating("col2", 0f, 0.02f);

       
    }
    void col2(){
         if (player.GetPosition.x == e2.GetPosition.x && player.GetPosition.y == e2.GetPosition.y)
        {
            SceneManager.LoadScene(2);
            PlayerPrefs.SetString("Status", "Lose");
        }
    }
    void followE3()
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)e3.GetPosition.x, (int)e3.GetPosition.y, (int)player.GetPosition.x, (int)player.GetPosition.y);
        e3.SetPath(path);
        e3.setSpeed(8f);
        e3.Move();
        col1();
        InvokeRepeating("col3", 0f, 0.02f);
        
    }
    void col3(){
        if (player.GetPosition.x == e3.GetPosition.x && player.GetPosition.y == e3.GetPosition.y)
        {
            SceneManager.LoadScene(2);
            PlayerPrefs.SetString("Status", "Lose");
        }
    }
    void followE4()
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)e4.GetPosition.x, (int)e4.GetPosition.y, (int)player.GetPosition.x, (int)player.GetPosition.y);
        e4.SetPath(path);
        e4.setSpeed(9f);
        e4.Move();
        InvokeRepeating("col4", 0f, 0.02f);

        
    }
    void col4(){
        if (player.GetPosition.x == e4.GetPosition.x && player.GetPosition.y == e4.GetPosition.y)
        {
            SceneManager.LoadScene(2);
            PlayerPrefs.SetString("Status", "Lose");
        }
    }
    void movementImput()
    {
        if (Input.GetKeyDown(up))
        {
            move((int)player.GetPosition.x, (int)player.GetPosition.y + 1);
        }

        if (Input.GetKeyDown(down))
        {
            move((int)player.GetPosition.x, (int)player.GetPosition.y - 1);

        }
        if (Input.GetKeyDown(left) == true)
        {
            move((int)player.GetPosition.x - 1, (int)player.GetPosition.y);
        }
        if (Input.GetKeyDown(right))
        {
            move((int)player.GetPosition.x + 1, (int)player.GetPosition.y);

        }
    }
    void Update()

    {
        //Capta el Input de Movimiento
        movementImput();
        //Seteo de Prefs para Manager de Tiempo y Nivel Máximo alcanzado
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
                    e2 = Instantiate(EnemyPrefab, new Vector2(n - 1, 0), Quaternion.identity);

                    manager.nextLevel();
                    break;
                case 2:
                    LevelName.text = "Level 3";
                    player.ResetPosition();
                    e1.ResetPosition(0, n - 1);
                    e2.ResetPosition(n - 1, 0);
                    e3 = Instantiate(EnemyPrefab, new Vector2(0, n - 3), Quaternion.identity);

                    manager.nextLevel();

                    break;
                case 3:
                    LevelName.text = "Level 4";
                    player.ResetPosition();
                    e1.ResetPosition(0, n - 1);
                    e2.ResetPosition(n - 1, 0);
                    e3.ResetPosition(0, n - 3);
                    e4 = Instantiate(EnemyPrefab, new Vector2(n - 3, 0), Quaternion.identity);
                    manager.nextLevel();
                    break;
                case 4:
                    PlayerPrefs.SetString("Status", "Win");
                    SceneManager.LoadScene(2);
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
