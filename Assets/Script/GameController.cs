using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject asteroid;
    public GameObject enemies;
    public GameObject Bolt;
    public Vector3 hazardPosition;

    public float spawnWait;

    public float wavesWait;
    public int hazardCount;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text highestScoreText;

    private int level;
    private int score;
    private static int highestScore;

    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        level = 1;
        Time.timeScale = 0;
        highestScoreText.text = "TOP:" + highestScore;
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine(hazardWaves(asteroid));
        StartCoroutine(hazardWaves(enemies));
    }


    void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R)
                ||Input.GetKeyDown(KeyCode.Backspace)
                ||(Application.platform == RuntimePlatform.Android 
                && (Input.GetKeyDown(KeyCode.Escape))))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator hazardWaves(GameObject other)
    {
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 position = new Vector3(Random.Range(-hazardPosition.x, hazardPosition.x), hazardPosition.y, hazardPosition.z);
                Instantiate(other, position, other.transform.rotation);
                yield return new WaitForSeconds(spawnWait);
                if (gameOver)
                {
                    restartText.text = "Press 'R' or '←' To Restart";
                    restart = true;
                    break;
                }
            }
            yield return new WaitForSeconds(wavesWait);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score:" + score;
        if (score % 100 == 0)
        {
            UpdateLevel();
        }
        if (score > highestScore)
        {
            highestScore = score;
            highestScoreText.text = "TOP:" + highestScore;
        }
    }

    void UpdateLevel()
    {
        level++;
        wavesWait = wavesWait / level;
        if (level % 10 == 0)
        {
            spawnWait = 0.1f;
            return;
        }

        if (level % 5 == 0)
        {
            spawnWait = 0.2f;
            return;
        }
        if (level > 5 && level < 10)
        {
            spawnWait = 0.7f;
        }
        if (level > 10)
        {
            spawnWait = 0.5f;
        }
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER!";
        gameOver = true;
    }


    public int GetSpeed()
    {
        return level;
    }
}