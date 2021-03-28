using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPlatform : MonoBehaviour
{
    public float Speed = 3f;
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

        // Platforms only update position when player moves laterally
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (moveUp)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + Speed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);
            }
        }

    }
}
