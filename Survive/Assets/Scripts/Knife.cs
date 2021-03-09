using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
    }
}
