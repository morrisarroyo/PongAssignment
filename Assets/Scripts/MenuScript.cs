using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text textTitle;
    public Button button1P;
    public Button button2P;
    public Text textSubtitle;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideMenu()
    {
        textTitle.color = Color.clear;

        textSubtitle.color = Color.clear;

        button1P.enabled = false;
        button1P.GetComponentInChildren<Text>().color = Color.clear;

        button2P.enabled = false;
        button2P.GetComponentInChildren<Text>().color = Color.clear;
    }

    public void ShowMenu()
    {
        textTitle.color = Color.white;

        textSubtitle.color = Color.white;

        button1P.enabled = true;
        button1P.GetComponentInChildren<Text>().color = Color.white;

        button2P.enabled = true;
        button2P.GetComponentInChildren<Text>().color = Color.white;
    }
}
