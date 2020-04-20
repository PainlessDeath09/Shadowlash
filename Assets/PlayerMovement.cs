using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator; 

    float HorizontalMove = 0f;
    public float runSpeed = 45f;
    public float rollSpeed;
    public float rollTime;

    bool jump = false, crouch = false, sprint = false;

    // Update is called once per frame
    void Update()
    { 
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
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
