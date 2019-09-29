using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    GameSession gameSession;
    Ball ball;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
        gameSession.LoseLife();
        if (gameSession.GetLives() <= 0)
            SceneManager.LoadScene("Defeated");
        else
            ball.SetBallBackToPaddle();
    }
}
