using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    [SerializeField] private LayerMask m_WhatIsGround;							
    // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							
    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded

    Rigidbody2D rb;
    public HealthBar healthBar;
    public float Speed = 25f;
    public float acceleration = 0.1f;
    private float curSpeed = 0f;
    private bool isMoving = false;
    private bool falling = false;
    private bool m_Grounded = false; 
    private PolygonCollider2D boxCollider2D;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<PolygonCollider2D>();
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
        if(IsGrounded()){
            Debug.Log("I'm grounded");
            
        }
    }

    // private void FixedUpdate()
	// {
	// 	bool wasGrounded = m_Grounded;
	// 	m_Grounded = false;

	// 	// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
	// 	// This can be done using layers instead but Sample Assets will not overwrite your project settings.
	// 	Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
	// 	for (int i = 0; i < colliders.Length; i++)
	// 	{
	// 		if (colliders[i].gameObject != gameObject)
	// 		{
	// 			m_Grounded = true;
	// 			if (!wasGrounded)
    //     {
    //     //   OnLandEvent.Invoke();
    //       Debug.Log("landed");
    //     }
	// 		}
	// 	}
	// }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.name.Equals("Player")){
            falling = true;
        }
    }

    private bool IsGrounded() {
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightText);
        Color rayColor; 
        if(raycastHit.collider != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightText), rayColor);

        return (raycastHit.collider != null);
    }


    void OnCollisionEnter2D (Collision2D col)
    {
      if(col.gameObject.tag == "Player") {
            healthBar.TakeDamage(5f);
            Destroy(this.gameObject);
      }
    }
}
