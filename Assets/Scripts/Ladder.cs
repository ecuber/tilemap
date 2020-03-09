using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public PlayerMovement playerMovement;
    
    Rigidbody2D rb;
    float x;
    float gravity;
    bool activated = false;
    bool inContact = false;

    public bool Climbing { get; set; } = false;

    private void Start()
    {
        gravity = playerMovement.getGravity();
        Debug.Log("Initialized Gravity as " + gravity);
    }

    public void TriggerEnter(Collider2D other)
    {
        rb = other.gameObject.GetComponent<Rigidbody2D>();
        activated = true;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }

    public void TriggerStay(Collider2D other)
    {
        if (!rb.velocity.Equals(Vector2.zero))
        {
            // play ladder sound effect
        }
        if (other.gameObject.name == "Player")
        {
            Climbing = true;
        }

        if (Input.GetButtonDown("Vertical"))
        {
            if (Input.GetAxisRaw("Vertical") > 0)
                rb.AddForce(new Vector2(rb.position.x, Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * playerMovement.ladderSpeed * 180));
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.down * playerMovement.ladderSpeed * 2);
            }
        }

    }

    public void TriggerExit(Collider2D other)
    {
        if (activated && other.gameObject.name == "Player")
        {
            Climbing = false;
            rb.gravityScale = gravity;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.down * gravity);
            rb.AddForce(new Vector2(rb.position.x, Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * playerMovement.ladderSpeed * -20));
        }
    }

   


}
