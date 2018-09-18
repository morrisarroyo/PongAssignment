using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text gameOverText;

    public float restartDelay = 5f;
    float restartTimer;
    bool gameOver = false;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // If the player has run out of health...
        if (gameOver)
        {
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                gameOverText.color = Color.clear;
                GameManager.instance.ResetGame();
                gameOver = false;
                restartTimer = 0f;
            }
        }
    }

    public void PlayGameOverAnimation(int winner)
    {
        gameOverText.text = "Player " + winner + " Wins";
        gameOverText.color = Color.white;
        gameOver = true;
    }
}
