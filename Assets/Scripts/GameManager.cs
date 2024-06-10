using UnityEngine;
using TMPro;
using System.Xml.Serialization;

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
            playGame = false;
            endGameText.text = "YOU WIN!";
            endGamePanel.SetActive(true);
            modalPanel.SetActive(true);
            dialogBorder.SetActive(true);
            Time.timeScale = freezeGame;
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
        Debug.Log("Quit.");
        Application.Quit();
    }
}
