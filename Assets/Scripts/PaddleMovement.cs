using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 10f;

    int playerNumber = 1;

    Vector3 movement;
    string input;

    const float WALL_Y_POS = 9;

    // Use this for initialization
    void Awake()
    {
        if (gameObject.name.EndsWith("2"))
        {
            playerNumber = 2;
        }
        input = "Vertical" + playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw(input);
        if (playerNumber == 1)
        {
            v += Input.GetAxisRaw("Vertical3");
        }
        //Debug.Log(gameObject.name + input);
        Move(v);
    }

    public void Move(float v)
    {
        if (Mathf.Abs(transform.position.y) < WALL_Y_POS
            || (transform.position.y >= WALL_Y_POS && v < 0)
            || (transform.position.y <= -WALL_Y_POS && v > 0))
        {
            movement.Set(0f, v, 0f);
        }
        else
        {
            movement = Vector3.zero;
        }
        transform.Translate(movement * Time.deltaTime * speed);
    }
}
