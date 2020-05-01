using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;

    float HorizontalMove = 0f;
    public float runSpeed = 45f;
    bool jump = false, crouch = false, sprint = false;

    // Update is called once per frame
    void Update()
    {
        /* 
         * Proceeding code is for PC controls
         * 
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        /*if (Input.GetButtonDown("Crouch"))
        {
            animator.SetBool("IsRolling",true);
            crouch = true;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            animator.SetBool("IsRolling", false);
            crouch = false;
        }
        if (Input.GetButtonDown("Sprint"))
        {
            sprint = true;
        }
        if(Input.GetButtonUp("Sprint"))
        {
            sprint = false;
        }
        *
        *
        */

        if(joystick.Horizontal >= 0.2f)
        {
            HorizontalMove = runSpeed;
        }
        else if(joystick.Horizontal <= -0.2f)
        {
            HorizontalMove = -runSpeed;
        }
        else
        {
            HorizontalMove = 0f;
        }
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if(joystick.Vertical >= 0.5f)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if(joystick.Vertical <= -0.5f)
        {
            animator.SetBool("IsRolling", true);
            crouch = true;
        }
        else
        {
            animator.SetBool("IsRolling", false);
            crouch = false;
        }



    }

    public void onLanding()
    {
        animator.SetBool("IsJumping",false);
    }

    private void FixedUpdate()
    {
       
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump, sprint);
        jump = false;

    }
}
