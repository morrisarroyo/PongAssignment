using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text p1ScoreText;
    public Text p2ScoreText;
    public int scoreToAdd = 1;

    int player1Score;
    int player2Score;




    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int player)
    {
        Debug.Log(player);

        if (player == 1)
        {
            AddPlayer1Score();
        }
        else
        {
            Debug.Log(player);
            AddPlayer2Score();
        }
        if (player1Score == 10 || player2Score == 10)
        {
            GameManager.instance.EndGame(player);
        }
    }

    public void AddPlayer1Score()
    {
        player1Score += scoreToAdd;
        p1ScoreText.text = player1Score.ToString();
    }

    public void AddPlayer2Score()
    {
        player2Score += scoreToAdd;
        p2ScoreText.text = player2Score.ToString();
    }

    public void resetScores()
    {
        player1Score = 0;
        player2Score = 0;
        p1ScoreText.text = player1Score.ToString();
        p2ScoreText.text = player2Score.ToString();
    }
}
