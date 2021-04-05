using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPace : MonoBehaviour
{
    public float Speed = 3f;
    private bool moveRight = true;
    public float extent = 3; // range of motion left to right
    public float startingPos = 0; // where platform starts in range of motion
    private float rightBound;
    private float leftBound;

    public HealthBar healthBar;

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

        // Platforms only update position when player moves laterally
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (moveRight)
            {
                transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);
            } else
            {
                transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y); ;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player") {
            healthBar.TakeDamage(5f);
        }
    }

}

