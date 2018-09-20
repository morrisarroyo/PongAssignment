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
    public Text consoleInputField;
    public Image consoleBackground;

    public MeshRenderer background;
    public MeshRenderer paddle1Renderer;
    public MeshRenderer paddle2Renderer;

    string inputText = "";
    // Use this for initialization
    void Awake()
    {
        gameObject.SetActive(false);
        consoleHistory = new List<string>();
        consoleHistoryText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        GetConsoleInput();
        if (Input.GetKeyDown(KeyCode.Return)) // Return == Enter
        {
            inputText = "";
            ProcessConsoleInput();
            PrintConsoleHistory();
        }
    }

    void QuitConsole()
    {
        gameObject.SetActive(false);
        GameManager.instance.inConsole = false;
        GameObject puck = GameObject.FindGameObjectWithTag("Puck");

        if (puck != null)
        {
            PuckMovement puckScript = puck.GetComponent<PuckMovement>();
            //Debug.Log("quitConsole: " + puck);
            puckScript.PlayMovement();
        }
    }

    public void OpenConsole()
    {
        gameObject.SetActive(true);
        GameObject puck = GameObject.FindGameObjectWithTag("Puck");

        if (puck != null)
        {
            PuckMovement puckScript = puck.GetComponent<PuckMovement>();
            puckScript.PauseMovement();
        }
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

    void GetConsoleInput()
    {

        if (Input.GetKeyDown(KeyCode.A)) { inputText += "a"; }
        else if (Input.GetKeyDown(KeyCode.B)) { inputText += "b"; }
        else if (Input.GetKeyDown(KeyCode.C)) { inputText += "c"; }
        else if (Input.GetKeyDown(KeyCode.D)) { inputText += "d"; }
        else if (Input.GetKeyDown(KeyCode.E)) { inputText += "e"; }
        else if (Input.GetKeyDown(KeyCode.F)) { inputText += "f"; }
        else if (Input.GetKeyDown(KeyCode.G)) { inputText += "g"; }
        else if (Input.GetKeyDown(KeyCode.H)) { inputText += "h"; }
        else if (Input.GetKeyDown(KeyCode.I)) { inputText += "i"; }
        else if (Input.GetKeyDown(KeyCode.J)) { inputText += "j"; }
        else if (Input.GetKeyDown(KeyCode.K)) { inputText += "k"; }
        else if (Input.GetKeyDown(KeyCode.L)) { inputText += "l"; }
        else if (Input.GetKeyDown(KeyCode.M)) { inputText += "m"; }
        else if (Input.GetKeyDown(KeyCode.N)) { inputText += "n"; }
        else if (Input.GetKeyDown(KeyCode.O)) { inputText += "o"; }
        else if (Input.GetKeyDown(KeyCode.P)) { inputText += "p"; }
        else if (Input.GetKeyDown(KeyCode.Q)) { inputText += "q"; }
        else if (Input.GetKeyDown(KeyCode.R)) { inputText += "r"; }
        else if (Input.GetKeyDown(KeyCode.S)) { inputText += "s"; }
        else if (Input.GetKeyDown(KeyCode.T)) { inputText += "t"; }
        else if (Input.GetKeyDown(KeyCode.U)) { inputText += "u"; }
        else if (Input.GetKeyDown(KeyCode.V)) { inputText += "v"; }
        else if (Input.GetKeyDown(KeyCode.W)) { inputText += "w"; }
        else if (Input.GetKeyDown(KeyCode.X)) { inputText += "x"; }
        else if (Input.GetKeyDown(KeyCode.Y)) { inputText += "y"; }
        else if (Input.GetKeyDown(KeyCode.Z)) { inputText += "z"; }
        else if (Input.GetKeyDown(KeyCode.Alpha0)) { inputText += "0"; }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) { inputText += "1"; }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { inputText += "2"; }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { inputText += "3"; }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) { inputText += "4"; }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) { inputText += "5"; }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) { inputText += "6"; }
        else if (Input.GetKeyDown(KeyCode.Alpha7)) { inputText += "7"; }
        else if (Input.GetKeyDown(KeyCode.Alpha8)) { inputText += "8"; }
        else if (Input.GetKeyDown(KeyCode.Alpha9)) { inputText += "9"; }
        else if (Input.GetKeyDown(KeyCode.Space)) { inputText += " "; }
        else if (Input.GetKeyDown(KeyCode.Backspace)) { inputText = inputText.Remove(inputText.Length - 1); }
        consoleInputField.text = inputText;
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
        consoleInputField.text = "";
    }

    void RunCommand(string command)
    {
        switch (command)
        {
            case "quit":
                QuitConsole();
                break;
            case "help":
                consoleHistory.Add("Commands: quit, backgroundcolor, paddle1color, paddle2color");
                break;
            case "backgroundcolor":
                background.material.color = getColor();
                break;
            case "paddle1color":
                paddle1Renderer.material.color = getColor();
                break;
            case "paddle2color":
                paddle2Renderer.material.color = getColor();
                break;
            default:
                consoleHistory.Add("Unknown Command");
                break;
        }
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
