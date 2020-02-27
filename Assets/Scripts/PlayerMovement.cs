using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D Controller;
    public float RunSpeed = 40f;
    float HorizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    //this part actally moves the guy
    private void FixedUpdate()
    {
        Controller.Move(HorizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
