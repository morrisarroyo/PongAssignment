using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour
{
    const int consoleHistoryTextMaxLength = 10;

    List<string> consoleHistory;

    public Text consoleHistoryText;
    public InputField consoleInputField;
    public MeshRenderer background;
    public MeshRenderer paddle1Renderer;
    public MeshRenderer paddle2Renderer;

    // Use this for initialization
    void Awake()
    {
        gameObject.SetActive(true);

        consoleInputField.ActivateInputField();
        consoleHistory = new List<string>();
        consoleHistoryText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Return == Enter
        {
            ProcessConsoleInput();
            PrintConsoleHistory();
            consoleInputField.text = "";
            consoleInputField.ActivateInputField();
        }
    }

    public void OpenConsole()
    {
        gameObject.SetActive(true);
        consoleInputField.ActivateInputField();
    }

    void PrintConsoleHistory()
    {
        int firstIndex = consoleHistory.Count >= consoleHistoryTextMaxLength ? consoleHistory.Count - consoleHistoryTextMaxLength : 0;
        string text = "";
        for (int i = firstIndex; i < consoleHistory.Count; ++i)
        {
            text += consoleHistory[i];
            if (i != consoleHistory.Count - 1)
            {
                text += "\n";
            }
        }
        consoleHistoryText.text = text;
    }

    void ProcessConsoleInput()
    {
        consoleHistory.Add(consoleInputField.text);
        if (consoleInputField.text.Trim().Length != 0)
        {
            if (consoleInputField.text.Trim().Split(' ').Length <= 2)
            {
                string commandString = consoleInputField.text.Trim().Split(' ')[0];
                RunCommand(commandString);
            }
            else
            {
                consoleHistory.Add("Invalid number of words");
            }
        }
    }

    void RunCommand(string command)
    {
        switch (command)
        {
            case "quit":
                gameObject.SetActive(false);
                break;
            case "help":
                consoleHistory.Add("Commands: quit, backgroundColor, paddle1Color, paddle2Color");
                break;
            case "backgroundColor":
                background.material.color = getColor();
                break;
            case "paddle1Color":
                paddle1Renderer.material.color = getColor();
                break;
            case "paddle2Color":
                paddle2Renderer.material.color = getColor();
                break;
            default:
                consoleHistory.Add("Unknown Command");
                break;
        }
    }
    void QuitConsole()
    {
        gameObject.SetActive(false);
    }

    Color getColor()
    {
        Color color = Color.gray;
        string colorString = consoleInputField.text.Trim().Split(' ')[1];
        switch (colorString)
        {
            case "black": color = Color.black; break;
            case "blue": color = Color.blue; break;
            case "cyan": color = Color.cyan; break;
            case "gray": color = Color.gray; break;
            case "grey": color = Color.grey; break;
            case "green": color = Color.green; break;
            case "magenta": color = Color.magenta; break;
            case "red": color = Color.red; break;
            case "white": color = Color.white; break;
            case "yellow": color = Color.yellow; break;
            default:
                consoleHistory.Add("Unknown Color - Color set to gray");
                break;
        }
        return color;
    }
}
