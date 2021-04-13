using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animations : MonoBehaviour
{
     Animator animator;

     void Start(){
        animator = GetComponent<Animator>();
     }

     void FixedUpdate(){
           //Run
           if (Input.GetKey ("a") || Input.GetKey ("d")) {
            animator.SetTrigger("run");
           } 
     }
}
