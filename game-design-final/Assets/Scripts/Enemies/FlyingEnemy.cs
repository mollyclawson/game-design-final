using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyingEnemy: MonoBehaviour
{

	[SerializeField]
	GameObject bullet;

	public float extent = 10f;
	public float starting_pos = 0;
	private bool movingUp = true;
	private bool isMoving = false;

	public float maxSpeed = 3f;
	private float curSpeed = 0f;
	public float acceleration = 0.1f;
	private float highest_pos;
	private float lowest_pos;

	// public HealthBar healthBar;
	public Hearts hearts;

	// once player is within this range, enemy will start to shoot
	public float range = 15f;
	public GameObject player;

	// distance enemy moves before firing again
	// fireDist is how much the enemy will move before firing again
	public float fireDist = 5f;
	private float nextFire;
	private float totalDist = 0f;
	private int timer = 0;

	// Use this for initialization
	void Start()
	{
		highest_pos = extent - starting_pos;
		lowest_pos = highest_pos - extent;
		nextFire = fireDist;
		hearts = (Hearts)GameObject.Find("Hearts").GetComponent(typeof(Hearts));
		player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update()
	{
		timer++;
		MoveSprite();
		CheckIfTimeToFire();
	}

	void MoveSprite()
    {
		// keep movement within bounds
		if (transform.position.y > highest_pos)
        {
			movingUp = false;
        } else if (transform.position.y < lowest_pos)
        {
			movingUp = true;
        }

		// determine if enemy should be moving based on input from player
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

		// update speed based on whether player is moving
		if (isMoving)
		{
			curSpeed = Mathf.Lerp(curSpeed, maxSpeed, acceleration);
		}
		else
		{
			curSpeed = 0;
		}
		

		// update position based on speed and direction
		
		if (movingUp)
		{
			transform.position = new Vector2(transform.position.x, transform.position.y + curSpeed * Time.deltaTime);
		}
		else
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - curSpeed * Time.deltaTime);
		}

		// update total distance
		totalDist = totalDist + Mathf.Abs(curSpeed * Time.deltaTime);
	}
	void CheckIfTimeToFire()

	{
		// fires only when it has traveled a certain amount of space AND player is within range
		if ((totalDist > nextFire) & (Vector3.Distance(player.transform.position, transform.position) < range))
		{
			//Debug.Log("should fire");
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = totalDist + fireDist;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player") {
            //timer is to avoid getting "hit" twice on the same collision
            if(timer >= 60) {
                hearts.takeDamage();
                timer = 0;
            } else {
                return;
            }
        }
	
	}

}
