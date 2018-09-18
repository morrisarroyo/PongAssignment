using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    Transform puckTr;
    Rigidbody rb;
    public float speed = 5f;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            puckTr = GameObject.FindGameObjectWithTag("Puck").transform;
            Vector3 movement = transform.position;
            movement.y = puckTr.position.y;
            if (puckTr.position.x >= 0)
            {
                Follow(movement);
            }
            Debug.Log(puckTr.position.x);
        }
    }

    public void Follow(Vector3 movement)
    {

        transform.position = Vector3.MoveTowards(transform.position, movement, Time.deltaTime * speed);
    }
}
