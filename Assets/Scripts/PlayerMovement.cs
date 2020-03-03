using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 50f;
    public float ladderSpeed = 50f;
    public Animator animator;
    

    float HorizontalMove = 0f;
    bool Jump = false;
    float gravity;

    void Start()
    {
        gravity = controller.getGravityScale();
    }

    public float getGravity()
    {
        return gravity;
    }

    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * 0.8f * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
            animator.SetBool("Jump", true);
        }


    }

    void OnLanding()
    {
        animator.SetBool("Jump", false);
    }

    void FixedUpdate()
    {
        controller.Move(HorizontalMove * Time.fixedDeltaTime, false, Jump);
        Jump = false;

    }

}
