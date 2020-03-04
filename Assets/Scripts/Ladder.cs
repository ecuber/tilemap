using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public PlayerMovement playerMovement;
    bool climbing = false;
    Rigidbody2D rb;
    float x;
    float gravity;
    bool activated = false;

    private void Start()
    {
        gravity = playerMovement.getGravity();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Connected");
        rb = other.gameObject.GetComponent<Rigidbody2D>();
        activated = true;
        if (other.gameObject.name == "Player")
        {
            climbing = true;
        }

        if (Input.GetButtonDown("Vertical") && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.1)
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
            climbing = false;
            rb.gravityScale = gravity;
            rb.AddForce(new Vector2(rb.position.x, Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * playerMovement.ladderSpeed * -20));
        }
    }

   


}
