using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector2Int size;
    public Vector2 offset;
    public GameObject enemy;
    private GameObject newEnemy;
    public GameObject enemies;
    public int enemyCount = 0;
    public bool lifeLost = false;
    public int lives = 5;
    public bool playGame = false;
    public GameObject[] livesImage;
    public Vector3 respawn = new Vector3(-1.6f, -4, 0);

    // Start is called before the first frame update
    void Start()
    {
        DrawEnemies();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawEnemies()
    {
        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                newEnemy = Instantiate(enemy, enemies.transform);
                newEnemy.transform.position = new Vector3(i * offset.x - 5.5f, j * offset.y + 0.8f, 0);
                enemyCount++;
            }
        }
    }
}
