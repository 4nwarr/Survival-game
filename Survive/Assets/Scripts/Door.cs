using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Photon.MonoBehaviour
{
    private Animator animator;
    private AudioSource aS;

    private void Start()
    {
        animator = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
    }
    public void OpenDoor(int i)
    {
        if (animator.GetBool("openBack") || animator.GetBool("openFront")){
            animator.SetBool("openBack", false);
            animator.SetBool("openFront", false);
        }
        else
        {
            if (i == 0){
                animator.SetBool("openBack", true);
            }
            else{
                animator.SetBool("openFront", true);
            }
        }
    }

    public void DoorOpenSound()
    {
        AudioSource.PlayClipAtPoint(aS.clip, transform.position, 1);
    }
}
