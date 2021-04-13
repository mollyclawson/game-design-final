using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerController controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public float acceleration = 0.1f;
    private float curSpeed = 0;
    bool jump = false;
    bool crouch = false;
    private Rigidbody2D m_Rigidbody2D;
   



    // Update is called once per frame
    void Update()
    {
        curSpeed = Mathf.Lerp(curSpeed, runSpeed, acceleration);
        // horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // updates current run speed based on how long button has been pressed
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * curSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            curSpeed = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    
    public void OnCrouching(bool isCrouching)
    {
      animator.SetBool("IsCrouching", isCrouching);
    }


    private void FixedUpdate()
    {
        controller.Move((horizontalMove * Time.fixedDeltaTime), crouch, jump);
        jump = false; 
    }

  

}
