using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator; 

    float HorizontalMove = 0f;
    public float runSpeed = 45f;
    bool jump = false, crouch = false, sprint = false;

    // Update is called once per frame
    void Update()
    { 
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        if (Input.GetButtonUp("Crouch"))
        {
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

    private void FixedUpdate()
    {
       
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump, sprint);
        jump = false;

    }
}
