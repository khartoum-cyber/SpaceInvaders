using UnityEngine;
using TMPro;
using System.Xml.Serialization;
using System.Collections;

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
    public bool enemyBreach = false;
    public TMP_Text scoreText;
    public int score = 0;
    public GameObject levelTwoOn;
    public GameObject levelTwoOff;
    public GameObject levelThreeOn;
    public GameObject levelThreeOff;
    public TMP_Text levelText;
    private int level = 1;
    public GameObject modalPanel;
    public GameObject startGamePanel;
    public GameObject dialogBorder;
    public TMP_Text level1HitPointsDisplay;
    public TMP_Text level2HitPointsDisplay;
    public TMP_Text level3HitPointsDisplay;
    public int level1HitPoints = 25;
    public int level2HitPoints = 50;
    public int level3HitPoints = 200;
    private const int freezeGame = 0;
    private const int unfreezeGame = 1;
    public GameObject endGamePanel;
    public TMP_Text endGameText;
    public GameObject exitGamePanel;
    private int hitPoints;
    public float enemySpeed;
    public float level1EnemySpeed = 0.5f;
    public float level2EnemySpeed = 0.4f;
    public float level3EnemySpeed = 0.3f;
    public float enemyFireRate;
    public float level1EnemyFireRate = 150f;
    public float level2EnemyFireRate = 125f;
    public float level3EnemyFireRate = 100f;
    private bool gameStart = true;
    private bool resetEnemies = false;
    public int timerResetCount;
    public int timerResetTime;
    public bool resetTimers = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        DrawEnemies();
        instance = this;
        LevelDisplay(level);
        level1HitPointsDisplay.text = level1HitPoints.ToString("000");
        level2HitPointsDisplay.text = level2HitPoints.ToString("000");
        level3HitPointsDisplay.text = level3HitPoints.ToString("000");
        modalPanel.SetActive(true);
        startGamePanel.SetActive(true);
        dialogBorder.SetActive(true);
        Time.timeScale = freezeGame;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString("00000");

        if ((lifeLost == true && lives <= 0) || enemyBreach == true)
        {
            playGame = false;
            lifeLost = false;
            enemyBreach = false;
            endGameText.text = "GAME OVER";
            modalPanel.SetActive(true);
            endGamePanel.SetActive(true);
            dialogBorder.SetActive(true);
            Time.timeScale = freezeGame;
        }
        else if (lifeLost == true)
        {
            lives -= 1;
            livesImage[lives].SetActive(false);
            lifeLost = false;
        }

        if(enemyCount == 0 && playGame == true)
        {
            if(level == 3)
            {
                playGame = false;
                endGameText.text = "YOU WIN!";
                endGamePanel.SetActive(true);
                modalPanel.SetActive(true);
                dialogBorder.SetActive(true);
                Time.timeScale = freezeGame;
            }
            else
            {
                playGame = false;
                LevelUp();
            }

        }

        if(Input.GetKeyDown(KeyCode.Escape) && !endGamePanel.activeInHierarchy && !startGamePanel.activeInHierarchy)
        {
            ExitPrompt();
        }
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

    private void ResetEnemies()
    {
        enemyCount = 0;

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                enemies.transform.GetChild(enemyCount).gameObject.SetActive(true);
                enemies.transform.GetChild(enemyCount).position = new Vector3(i * offset.x - 5.5f, j * offset.y + 0.8f, 0);
                enemyCount++;
            }
        }

        resetEnemies = false;
    }

    public void Restart()
    {
        if (modalPanel.activeInHierarchy)
        {
            modalPanel.SetActive(false);
        }

        if (startGamePanel.activeInHierarchy)
        {
            startGamePanel.SetActive(false);
            dialogBorder.SetActive(false);
            Time.timeScale = unfreezeGame;
        }

        if (endGamePanel.activeInHierarchy)
        {
            endGamePanel.SetActive(false);
            dialogBorder.SetActive(false);
            Time.timeScale = unfreezeGame;
        }

        level = 1;
        LevelDisplay(level);
        score = 0;
        scoreText.text = score.ToString("00000");
        hitPoints = level1HitPoints;
        enemySpeed = level1EnemySpeed;
        enemyFireRate = level1EnemyFireRate;

        if (gameStart == false)
        {
            ResetGame();
        }
        else
        {
            gameStart = false;
        }
    }

    public void ResetGame()
    {
        StopAllCoroutines();
        StartCoroutine(GameReset());
    }

    IEnumerator GameReset()
    {
        GameObject[] objectsToDestroy;
        objectsToDestroy = GameObject.FindGameObjectsWithTag("Projectile");

        foreach(GameObject singleObject in objectsToDestroy)
        {
            Destroy(singleObject);
        }

        for (int i = 0; i <= 4; i++)
        {
            livesImage[i].SetActive(true);
        }

        resetEnemies = true;
        ResetEnemies();

        while (resetEnemies == true)
            yield return null;

        timerResetCount = 0;
        resetTimers = true;

        while (timerResetCount < enemyCount)
            yield return null;

        resetTimers = false;
        player.transform.position = respawn;
        lives = 5;
    }

    private void LevelUp()
    {
        if (level == 1)
        {
            level = 2;
            LevelDisplay(level);
            hitPoints = level2HitPoints;
            enemySpeed = level2EnemySpeed;
            enemyFireRate = level2EnemyFireRate;
            ResetGame();
        }
        else if (level == 2)
        {
            level = 3;
            LevelDisplay(level);
            hitPoints = level3HitPoints;
            enemySpeed = level3EnemySpeed;
            enemyFireRate = level3EnemyFireRate;
            ResetGame();
        }
    }

    private void LevelDisplay(int newLevel)
    {
        switch (newLevel)
        {
            case 1:
                levelTwoOn.SetActive(false);
                levelTwoOff.SetActive(true);
                levelThreeOn.SetActive(false);
                levelThreeOff.SetActive(true);
                break;
            case 2:
                levelTwoOn.SetActive(true);
                levelTwoOff.SetActive(false);
                levelThreeOn.SetActive(false);
                levelThreeOff.SetActive(true);
                break;
            case 3:
                levelTwoOn.SetActive(true);
                levelTwoOff.SetActive(false);
                levelThreeOn.SetActive(true);
                levelThreeOff.SetActive(false);
                break;
        }

        levelText.text = newLevel.ToString("0");
    }

    public void ExitPrompt()
    {
        modalPanel.SetActive(true);
        exitGamePanel.SetActive(true);
        dialogBorder.SetActive(true);
        Time.timeScale = freezeGame;
    }

    public void NoExit()
    {
        modalPanel.SetActive(false);
        exitGamePanel.SetActive(false);
        dialogBorder.SetActive(false);
        Time.timeScale = unfreezeGame;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
