using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderConfigurator : MonoBehaviour
{
    public enum Materials{Wood, Metal};
    public Materials material;

    public bool isTop = false;

    public Animator animator;

    void Update()
    {
        animator.SetBool("IsWood", material == Materials.Wood);
        animator.SetBool("IsTop", isTop);
    }

}
