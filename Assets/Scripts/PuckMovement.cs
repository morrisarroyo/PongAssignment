using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckMovement : MonoBehaviour
{
    public float initialXVelocity = 1.0f;
    public float maxDirectionalVelocity = 10.0f;
    public float addedVelocity = .25f;
    public float yVelocityMultiplier = 1.0f;

    BoxCollider boxCollider;
    Rigidbody rb;
    Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        velocity = Vector3.left * initialXVelocity;
        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WallReflect()
    {
        //Debug.Log(velocity.x + " " + velocity.y);
        rb.velocity = new Vector3(velocity.x, -velocity.y);
        velocity = rb.velocity;
    }

    public void PaddleReflect(float addedYVelocity)
    {
        //Debug.Log("velocity.yAT: " + velocity.y + " addedYVelocity: " + addedYVelocity);
        rb.velocity = new Vector3(-velocity.x, velocity.y)
            + new Vector3(addedVelocity * Mathf.Sign(velocity.x), addedYVelocity * yVelocityMultiplier);
        //xVelocityMultiplier += addedVelocity;
        //Debug.Log("velocity.yAFTER: " + rb.velocity.y);

        if (Mathf.Abs(rb.velocity.x) >= maxDirectionalVelocity)
            rb.velocity = new Vector3(maxDirectionalVelocity * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) >= maxDirectionalVelocity)
            rb.velocity = new Vector3(rb.velocity.x, maxDirectionalVelocity * Mathf.Sign(rb.velocity.y));
        if (Mathf.Abs(addedYVelocity) < .2)
        {
            rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * rb.velocity.magnitude, 0);
        }
        velocity = rb.velocity;
        //Debug.Log("velocity.yAFTER2: " + rb.velocity.y);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.gameObject.name);
        if (collision.collider.tag == "Wall")
        {
            WallReflect();
        }
        else if (collision.collider.tag == "Paddle")
        {
            //Debug.Log("Paddle: " + (transform.position.y - collision.collider.gameObject.transform.position.y));
            PaddleReflect(transform.position.y - collision.collider.gameObject.transform.position.y);

        }
    }

    void AddScore(float ballXPosition)
    {
        if (Mathf.Sign(ballXPosition) == 1f)
        {
            GameManager.instance.scoreScript.AddScore(1);
        }
        else
        {
            GameManager.instance.scoreScript.AddScore(2);
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("Puck.OnTriggerEnter Enter");
        if (collider.tag == "Boundary")
        {
            AddScore(collider.transform.position.x);
            Destroy(gameObject);
            GameManager.instance.ResetLevel();
        }
    }
}
