using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public ScoreManager scoreScript;
    public MenuScript menuScript;
    public PaddleAI paddleAI;
    public ConsoleScript consoleScript;


    public bool gameOver;
    public bool isPlaying = false;

    bool aiP2 = false;
    bool pause = false;
    private PuckManager puckScript;
    private GameOverManager gameOverScript;
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        puckScript = GetComponent<PuckManager>();
        scoreScript = GetComponent<ScoreManager>();
        gameOverScript = GetComponent<GameOverManager>();
        gameOver = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            consoleScript.OpenConsole();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button4) && !isPlaying )
        {
            Start1PGame();
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button5) && !isPlaying)
        {
            Start2PGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isPlaying)
        {
            Start1PGame();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !isPlaying)
        {
            Start2PGame();
        }

    }

    public void Start1PGame()
    {
        gameOver = false;
        aiP2 = true;
        menuScript.HideMenu();
        ResetLevel();
    }

    public void Start2PGame()
    {
        gameOver = false;
        aiP2 = false;
        menuScript.HideMenu();
        ResetLevel();
    }

    public void ResetLevel()
    {
        if (!gameOver)
            puckScript.Spawn();
    }

    public void EndGame(int winner)
    {
        gameOver = true;
        gameOverScript.PlayGameOverAnimation(winner);

    }

    public void ResetGame()
    {
        menuScript.ShowMenu();
        scoreScript.resetScores();
        gameOver = false;
        aiP2 = false;
        isPlaying = false;
    }
}
