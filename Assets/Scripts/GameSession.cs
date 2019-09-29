using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Range(.1f, 10f)] [SerializeField] float timeSpeed = 1f;
    [SerializeField] int PointsPerBlockDestroyed = 83;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] bool isAutoPlayEnabled;
    int level;
    int lives;
    // Start is called before the first frame update

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
      
    }
    private void Start()
    {
        UpdateScoreText();
        level = 1;
        lives = 3;
    }

    public bool IsAutoPlayEnabled()
    {
       return isAutoPlayEnabled;
    }

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = timeSpeed;
        
    }

    public void IncreaseScore()
    {
        currentScore += PointsPerBlockDestroyed;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore;
    }

    public void DestroyItself()
    {
        Destroy(gameObject);
    }

    public void increaseLevel()
    {
        level++;
        levelText.text = "Level: " + level;
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;

    }

    public int GetLives()
    {
        return lives;
    }
}
