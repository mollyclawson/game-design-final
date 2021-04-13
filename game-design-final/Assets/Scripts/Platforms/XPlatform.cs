using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPlatform : MonoBehaviour
{
    public float Speed = 3f;
    public float acceleration = 0.1f;
    private float curSpeed = 0f;
    private bool isMoving = false;
    private bool moveRight = true;
    public float extent = 3; // range of motion left to right
    public float startingPos = 0; // where platform starts in range of motion
    private float rightBound;
    private float leftBound;


    private void Start()
    {
        leftBound = transform.position.x - startingPos;
        rightBound = leftBound + extent;
    }


    // Update is called once per frame 
    void Update()
    {

        if (transform.position.x > rightBound)
        {
            moveRight = false;
        } else if (transform.position.x < leftBound)
        {
            moveRight = true;
        }

        // Platforms move if player is crouching or moving laterally
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        if (Input.GetAxisRaw("Crouch") != 0)
        {
            isMoving = true;
        }

        // if platforms are moving, they accelerate to max speed. otherwise they stop
        if (isMoving)
        {
            curSpeed = Mathf.Lerp(curSpeed, Speed, acceleration);
        }
        else
        {
            curSpeed = 0;
        }

        // do transform based on direction of movement
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + curSpeed * Time.deltaTime, transform.position.y);
        } else
        {
            transform.position = new Vector2(transform.position.x - curSpeed * Time.deltaTime, transform.position.y); ;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
            //collision.gameObject.transform.SetParent(null);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("no longer in contact");
            collision.gameObject.transform.SetParent(null);
        }
    }

}
