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
    private bool climbing = false;
    public bool Climbing { get => climbing; set => climbing = value; }

    private void Start()
    {
        gravity = playerMovement.getGravity();
        Debug.Log("Initialized Gravity as " + gravity);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Connected");
        rb = other.gameObject.GetComponent<Rigidbody2D>();
        activated = true;
        if (other.gameObject.name == "Player")
        {
            Climbing = true;
        }

        if (Input.GetButtonDown("Vertical"))
        {
            rb.gravityScale = 0f;
            rb.AddForce(new Vector2(rb.position.x, Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * playerMovement.ladderSpeed * 100));
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Disconnected");
        if (activated && other.gameObject.name == "Player")
        {
            Climbing = false;
            rb.gravityScale = gravity;
<<<<<<< HEAD
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.down * gravity);
=======
            rb.AddForce(new Vector2(rb.position.x, Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * playerMovement.ladderSpeed * -20));
>>>>>>> 7837a06d832dca9a16484b58e3242f517bb3db24
        }
    }

   


}
