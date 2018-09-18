using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckManager : MonoBehaviour
{
    public GameObject puck;


    public Transform[] spawnPoints;


    // Use this for initialization
    void Start()
    {

    }

    public void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(puck, spawnPoints[spawnPointIndex]);
    }
}
