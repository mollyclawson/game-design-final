using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerController controller;
    public Animator animator;
    public Transform t_form;
    float horizontalMove = 0f;
    private float time_scale = 0f;
    public float runSpeed = 40f;
    public float acceleration = 0.1f;
    public float curSpeed = 0f;
    public float timeDecel = 0.1f;
    bool jump = false;
    bool crouch = false;
    private Rigidbody2D m_Rigidbody2D;
    public bool isDead;


    // Update is called once per frame
    void Update()
    {
      if(!isDead)
      {
        curSpeed = Mathf.Lerp(curSpeed, runSpeed, acceleration);
        
        // horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // updates current run speed based on how long button has been pressed
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * curSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            curSpeed = 0;
            if (Input.GetAxisRaw("Crouch") == 0)
            {
                //time_scale -= Mathf.Lerp(time_scale, runSpeed, acceleration * 0.1f);
                time_scale = Mathf.Lerp(time_scale, 0.0f, acceleration);
            }
            else time_scale = Mathf.Lerp(time_scale, runSpeed, acceleration);
        }
        else time_scale = Mathf.Lerp(time_scale, runSpeed, acceleration);

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
      } else {
        horizontalMove = 0f;
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

    public float timeScale()
    {
        // Debug.Log("Time scale is" + time_scale / runSpeed);
        return time_scale / runSpeed;
    }

}

    
