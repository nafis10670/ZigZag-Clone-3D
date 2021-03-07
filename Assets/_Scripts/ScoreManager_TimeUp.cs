using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager_TimeUp : MonoBehaviour
{
    //public GameManager gameManager;
    public Text YourScoreText;
    public Text HighScoreText;


    private void Awake()
    {
        YourScoreText.text = GameManager.Score.ToString();
        HighScoreText.text = "High Score: " + GameManager.GetHighScore();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }
}
