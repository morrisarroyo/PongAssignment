using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.ToString());
        if (collision.collider.tag == "Puck")
            collision.collider.GetComponent<PuckMovement>().WallReflect();
    }
    */
}
