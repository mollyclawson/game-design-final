using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPlatform : MonoBehaviour
{
    public float Speed = 3f;
    public float acceleration = 0.1f;
    private float curSpeed = 0f;
    private bool isMoving = false;
    private bool moveUp = true;
    public float extent = 3; // range of motion up and down
    public float startingPos = 0; // where platform starts in range of motion
    private float upperBound;
    private float lowerBound;


    private void Start()
    {
        lowerBound = transform.position.x - startingPos;
        upperBound = lowerBound + extent;
    }


    // Update is called once per frame 
    void Update()
    {
        if (transform.position.y > upperBound)
        {
            moveUp = false;
        }
        else if (transform.position.y < lowerBound)
        {
            moveUp = true;
        }

        // Platforms only move when player moves laterally or is crouching
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
        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + curSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - curSpeed * Time.deltaTime);
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
            //Debug.Log("no longer in contact");
            collision.gameObject.transform.SetParent(null);
        }
    }
}
