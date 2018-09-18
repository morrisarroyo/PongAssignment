﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;          //GameManager prefab to instantiate.

    // Use this for initialization
    void Awake()
    {
        if (GameManager.instance == null)

            //Instantiate gameManager prefab
            Instantiate(gameManager);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
