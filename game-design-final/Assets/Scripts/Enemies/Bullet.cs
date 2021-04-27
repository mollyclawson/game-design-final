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
    //GameObject go = GameObject.Find("Hearts");
    public Hearts hearts; 

    Rigidbody2D rb;

    private Transform target;
    private Vector2 moveDir;
    private int timer = 0;
	

	// Use this for initialization
	void Start()
	{
        Debug.Log("bullet start");
        // must do this otherwise new bullets don't cause damage
        hearts = (Hearts)GameObject.Find("Hearts").GetComponent(typeof(Hearts));
        rb = GetComponent<Rigidbody2D>();
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

        //transform.position = new Vector2(transform.position.x + moveDir.x * curSpeed/maxSpeed * Time.deltaTime, transform.position.y + moveDir.y * curSpeed/maxSpeed * Time.deltaTime);
        rb.velocity = new Vector2(moveDir.x * curSpeed /maxSpeed, moveDir.y * curSpeed /maxSpeed);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit player!");
            hearts.takeDamage();
            //gameObject.SetActive(false);
            Destroy(gameObject);
            
        }
        else if (col.gameObject.tag == "Playground")
        {
            //Debug.Log("Playground collision");
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
	}


}
