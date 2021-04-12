using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    Rigidbody2D rb;
    public HealthBar healthBar;
    public float Speed = 25f;
    private bool falling = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (falling && Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);
        }
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
