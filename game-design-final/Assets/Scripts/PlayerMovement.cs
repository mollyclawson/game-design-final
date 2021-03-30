﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerController controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnCrouching (bool IsCrouching)
    {
        animator.SetBool("isCrouching", IsCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move((horizontalMove * Time.fixedDeltaTime), crouch, jump);
        jump = false; 
    }
}
