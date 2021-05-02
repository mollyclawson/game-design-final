using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    [SerializeField] private LayerMask m_WhatIsGround;							
    // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							
    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .8f; // Radius of the overlap circle to determine if grounded

    Rigidbody2D rb;
    public Hearts hearts;
    public float Speed = 25f;
    public float acceleration = 0.1f;
    private float curSpeed = 0f;
    private bool isMoving = false;
    private bool falling = false;
    private bool m_Grounded = false; 
    private PolygonCollider2D boxCollider2D;

    public SoundManager soundManager;
    private AudioSource icicleSound;
    
    // public AudioSource audioSource;
    // public AudioClip sound;
    
    // [RequireComponent(typeof(AudioSource))]
    // public class Example : MonoBehaviour;
    // 
    // public AudioClip clip;
    // 

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

    }

    private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
                {   
                // AudioSource.PlayClipAtPoint(clip, transform.position);
                soundManager.playIceSound();
                Destroy(this.gameObject);
                }
			}
		}
	}

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.name.Equals("Player")){
            falling = true;
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y);
        Color rayColor; 
        if(raycastHit.collider != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * boxCollider2D.bounds.extents.y, rayColor);

        return (raycastHit.collider != null);
    }


    void OnCollisionEnter2D (Collision2D col)
    {
      if(col.gameObject.tag == "Player") {
            hearts.takeDamage();
            soundManager.playIceSound();
            // healthBar.TakeDamage(5f);
            Destroy(this.gameObject);
      }
    }
}
