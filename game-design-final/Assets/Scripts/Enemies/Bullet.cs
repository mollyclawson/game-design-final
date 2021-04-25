using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float maxSpeed = 7f;
	private float curSpeed = 0f;
    private bool isMoving = false;
    private float acceleration = 0.1f;

    // public HealthBar healthBar;
    public Hearts hearts;

    Rigidbody2D rb;

    private Transform target;
    private Vector2 moveDir;
    private int timer = 0;
	

	// Use this for initialization
	void Start()
	{
       
        target = GameObject.FindGameObjectWithTag("Player").transform;
        moveDir = (target.transform.position - transform.position).normalized * maxSpeed;
        


    }

    private void Update()
    {
        timer++;
        // bullets move when players crouch or are 
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

        // if bullet is moving, they accelerate to max speed. otherwise they stop
        if (isMoving)
        {
            curSpeed = Mathf.Lerp(curSpeed, maxSpeed, acceleration);
        }
        else
        {
            curSpeed = 0;
        }

        transform.position = new Vector2(transform.position.x + moveDir.x * curSpeed/maxSpeed * Time.deltaTime, transform.position.y + moveDir.y * curSpeed/maxSpeed * Time.deltaTime);
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit!");
            hearts.takeDamage();
            gameObject.SetActive(false);
            
        }
        else if (col.gameObject.tag == "Playground")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
	}


}
