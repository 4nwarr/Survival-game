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
    public void OpenDoor()
    {
        if (animator.GetBool("open"))
            animator.SetBool("open", false);
        else
            animator.SetBool("open", true);
    }

    public void DoorOpenSound()
    {
        AudioSource.PlayClipAtPoint(aS.clip, transform.position, 1);
    }
}
