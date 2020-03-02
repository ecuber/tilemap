using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 50f;
    public float ladderSpeed = 50f;
    public LayerMask whatIsLadder;

    float HorizontalMove = 0f;
    bool Jump = false;
    float Distance = 3f;
    bool IsClimbing;
    float gravity;

    void Start()
    {
        gravity = controller.getGravityScale();
    }

    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * 0.8f * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }

    }

    //this part actally moves the guy
    void FixedUpdate()
    {
        controller.Move(HorizontalMove * Time.fixedDeltaTime, false, Jump);
        Jump = false;

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, Distance, whatIsLadder);

        if (hitInfo.collider != null)
        {
            if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
            {
                Debug.Log("Trying to climb.");
                IsClimbing = true;
            } else
            {
                IsClimbing = false;
            }
        }

        Rigidbody2D rigidbody = controller.getRigidBody2D();

        if (IsClimbing)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, Input.GetAxisRaw("Vertical") * ladderSpeed);
            rigidbody.gravityScale = 0.25f * gravity;
        } else
        {
            rigidbody.gravityScale = gravity;
        }
    }

}
