using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StationaryShooter : MonoBehaviour
{

	[SerializeField]
	GameObject bullet;

	// public HealthBar healthBar;
	public Hearts hearts;

	// once player is within this range, enemy will start to shoot
	public float range = 15f;
	public GameObject player;

	// distance enemy moves before firing again
	// fireDist is how much the enemy will move before firing again
	public float fireDist = 10f;
	private float nextFire;
	private float totalDist = 0f;
	private int timer = 0;
	private Vector3 lastPos;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");
		nextFire = fireDist;
		lastPos = player.transform.position;
		hearts = (Hearts)GameObject.Find("Hearts").GetComponent(typeof(Hearts));
		player = GameObject.Find("Player");
	}


	// Update is called once per frame
	void Update()
	{
		timer++;
		CheckIfTimeToFire();
		totalDist = totalDist + Vector3.Distance(player.transform.position, lastPos);
		lastPos = player.transform.position;
	}

	
	void CheckIfTimeToFire()

	{
		// fires only when player traveled a certain amount of space AND player is within range
		if ((totalDist > nextFire) & (Vector3.Distance(player.transform.position, transform.position) < range))
		{
			//Debug.Log("should fire");
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = totalDist + fireDist;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			//timer is to avoid getting "hit" twice on the same collision
			if (timer >= 60)
			{
				hearts.takeDamage();
				timer = 0;
			}
			else
			{
				return;
			}
		}

	}

}

