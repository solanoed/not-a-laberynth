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
    private Grid grid;
    private Player player , en1, en2,en3,en4;
    [SerializeField]
    private float moveSpeed = 3f;
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
        LevelName.text="Level 1";
        grid = new Grid(n, n, 1, CellPrefab, endPrefab, m);
        player = Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);
                
    }
    void FixedUpdate(){
        // Diagonales
        // Up - Right
        if(grid.gridArray[(int) player.GetPosition.x+(int)horizontalMove,(int) player.GetPosition.y+(int)verticalMove].isWalkable){
            player.transform.position = Vector2.MoveTowards(player.transform.position,grid.gridArray[(int) player.GetPosition.x+(int)horizontalMove,(int) player.GetPosition.y+(int)verticalMove].Position,moveSpeed * Time.deltaTime);
        }
    }
    void Update()

    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        Debug.Log(horizontalMove+" "+verticalMove);
        PlayerPrefs.SetString("Time",time.text);
        PlayerPrefs.SetString("Level",LevelName.text);
        
        if (player.GetPosition.x == n - 1 && player.GetPosition.y == n - 1)
        {   
            switch (manager.Level)
            {
                case 1:
                    Debug.Log("Level 1 To Level 2");
                    LevelName.text="Level 2";
                    player.ResetPosition();
                    en1=Instantiate(PlayerPrefab, new Vector2(n-1,0 ), Quaternion.identity);
                    manager.nextLevel();
                    break;
                case 2:
                    LevelName.text="Level 3";
                    player.ResetPosition();
                    en1=Instantiate(PlayerPrefab, new Vector2(0, n-1), Quaternion.identity);
                    manager.nextLevel();
                    SceneManager.LoadScene(2);
                    
                    break;
                case 3:
                    LevelName.text="Level 4";
                    player.ResetPosition();
                    manager.nextLevel();
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
