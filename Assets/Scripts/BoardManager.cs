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
        PlayerPrefs.SetString("Status", "None");

        grid = new Grid(n, n, 1, CellPrefab, endPrefab, m);
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
        e1.setSpeed(3f);
        e1.Move();
        if (player.GetPosition.x == e1.GetPosition.x && player.GetPosition.y == e1.GetPosition.y)
        {
            PlayerPrefs.SetString("Status", "Lose");
            SceneManager.LoadScene(2);
        }
    }
    void followE2()
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)e2.GetPosition.x, (int)e2.GetPosition.y, (int)player.GetPosition.x, (int)player.GetPosition.y);
        e2.SetPath(path);
        e2.setSpeed(5f);
        e2.Move();
        if (player.GetPosition.x == e2.GetPosition.x && player.GetPosition.y == e2.GetPosition.y)
        {
            PlayerPrefs.SetString("Status", "Lose");
            SceneManager.LoadScene(2);
        }
    }
    void followE3()
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)e3.GetPosition.x, (int)e3.GetPosition.y, (int)player.GetPosition.x, (int)player.GetPosition.y);
        e3.SetPath(path);
        e3.setSpeed(6f);
        e3.Move();
        if (player.GetPosition.x == e3.GetPosition.x && player.GetPosition.y == e3.GetPosition.y)
        {
            PlayerPrefs.SetString("Status", "Lose");
            SceneManager.LoadScene(2);
        }
    }
    void followE4()
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)e4.GetPosition.x, (int)e4.GetPosition.y, (int)player.GetPosition.x, (int)player.GetPosition.y);
        e4.SetPath(path);
        e4.setSpeed(8f);
        e4.Move();
        if (player.GetPosition.x == e4.GetPosition.x && player.GetPosition.y == e4.GetPosition.y)
        {
            PlayerPrefs.SetString("Status", "Lose");
            SceneManager.LoadScene(2);
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
        // Si llega al final Pasa al siguiente nivel
        // if (e)
        // {

        // }

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
