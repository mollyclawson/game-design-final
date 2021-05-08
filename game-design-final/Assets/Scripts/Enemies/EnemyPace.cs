using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPace : MonoBehaviour
{
    public float Speed = 3f;
    public float acceleration = 0.1f;
    private float curSpeed = 0f;
    private bool moveRight = true;
    private bool isMoving = false;
    public float extent = 3; // range of motion left to right
    public float startingPos = 0; // where platform starts in range of motion
    private float rightBound;
    private float leftBound;
    public float collisionForce;

    // public HealthBar healthBar;
    public Hearts hearts;
    private int timer = 0;
    public bool isDead;

    private void Start()
    {
        leftBound = transform.position.x - startingPos;
        rightBound = leftBound + extent;
        hearts = (Hearts)GameObject.Find("Hearts").GetComponent(typeof(Hearts));

    }

    // Update is called once per frame 
    void Update()
    {
        timer++;
        if (transform.position.x > rightBound)
        {
            moveRight = false;
        } else if (transform.position.x < leftBound)
        {
            moveRight = true;
        }


        // Enemies move if player is crouching or moving laterally
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            isMoving = false;
        } else
        {
            isMoving = true;
        }
        if (Input.GetAxisRaw("Crouch") != 0)
        {
            isMoving = true;
        }
        
        if (isDead)
        {
            isMoving = false;
        }
   

        // if Enemies are moving, they accelerate to max speed
        // otherwise they stop instantly
        if (isMoving)
        {
            curSpeed = Mathf.Lerp(curSpeed, Speed, acceleration);
        } else {
            curSpeed = 0;
        }
      
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + curSpeed * Time.deltaTime, transform.position.y);
        } else
        {
            transform.position = new Vector2(transform.position.x - curSpeed * Time.deltaTime, transform.position.y); ;
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player") {
            //timer is to avoid getting "hit" twice on the same collision
            if(timer >= 60) {
                hearts.takeDamage();
                // Vector2 force = -collision.rigidbody.velocity.normalized * collisionForce;
                // Debug.Log("Force is" + force);
                // collision.rigidbody.AddForce(force, ForceMode2D mode = ForceMode2D.Force);
                timer = 0;
            } else {
                return;
            }
        }
    }
}

