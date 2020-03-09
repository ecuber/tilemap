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
            Debug.Log("Initialized Contact");
            parent.TriggerEnter(other);
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        parent.TriggerStay(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (triggering)
        {
            triggering = false;
            Debug.Log("Ended Contact");
            parent.TriggerExit(other);
        }
       
    }
}
