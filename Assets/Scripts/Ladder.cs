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

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Contact");
        rb = other.gameObject.GetComponent<Rigidbody2D>();
        activated = true;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Climbing = true;
        }

        if (Input.GetButtonDown("Vertical"))
        {
            rb.AddForce(new Vector2(rb.position.x, Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * playerMovement.ladderSpeed * 100));
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Disconnect");
        if (activated && other.gameObject.name == "Player")
        {
            Climbing = false;
            rb.gravityScale = gravity;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.down * gravity);
            rb.AddForce(new Vector2(rb.position.x, Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * playerMovement.ladderSpeed * -20));
            //inContact = false;
        }
    }

   


}
