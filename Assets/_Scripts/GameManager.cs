using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStarted;
    
    public static int Score;

    private float startTime = 60f;
    
    public Text scoreText;
    public Text highScoreText;
    public Text timerText;
    
    public bool canAppear;
    //public Road road;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;

        Score = 0;
        highScoreText.text = "High Score: " + GetHighScore().ToString();
        timerText.text = "Timer: " + startTime;
    }

    private void Start()
    {
        canAppear = false;

    }

    public void StartGame()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
            //FindObjectOfType<Road>().StartBuilding();
        }

        if (gameStarted)
        {
            DecreaseTimer();
            timerText.text = "Timer: " + startTime.ToString("0");
            if(startTime <= 0)
                SceneManager.LoadScene(3);
        }
            
    }

    public void EndGame()
    {
        SceneManager.LoadScene(2);
    }

    public void IncreaseScore()
    {
        Score++;
        scoreText.text = "Score: " + Score.ToString();

        startTime += 2f;

        if(Score > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", Score);
            highScoreText.text = "High Score: " + Score.ToString();
        }
    }

    public static int GetHighScore()
    {
        int x = PlayerPrefs.GetInt("Highscore");
        return x;
    }

    private void DecreaseTimer()
    {
        startTime -= 1 * Time.deltaTime;
    }
}
