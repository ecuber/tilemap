using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderChild : MonoBehaviour
{
    public Ladder parent;
    private bool triggering;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggering)
        {
            triggering = true;
            Debug.Log("Entered trigger");
            parent.TriggerEnter(other);
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Trigger Stay");
        parent.TriggerStay(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (triggering)
        {
            triggering = false;
            Debug.Log("Exited Trigger");
            parent.TriggerExit(other);
        }
       
    }
}
