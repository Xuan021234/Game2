using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    bool jump = false;
    float horizontalMove = 0f;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    public void TouchFloor()
    {
        animator.SetBool("IsJumping", false);
    }

}

