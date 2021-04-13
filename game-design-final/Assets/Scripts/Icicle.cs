using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    Rigidbody2D rb;
    public HealthBar healthBar;
    public float Speed = 25f;
    public float acceleration = 0.1f;
    private float curSpeed = 0f;
    private bool isMoving = false;
    private bool falling = false;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (falling && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Crouch") != 0))
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            curSpeed = Mathf.Lerp(curSpeed, Speed, acceleration);
        } else
        {
            curSpeed = 0;
        }
        transform.position = new Vector2(transform.position.x, transform.position.y - curSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.name.Equals("Player")){
            falling = true;
        }
    }


    void OnCollisionEnter2D (Collision2D col)
    {
      if(col.gameObject.tag == "Player") {
            healthBar.TakeDamage(5f);
            Destroy(this.gameObject);
      }
    }
}
