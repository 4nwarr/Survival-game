using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject jumpScareImage;
    public AudioSource jumpScareSound;
    public Animator an;

    private void Start()
    {
        jumpScareSound = GetComponent<AudioSource>();
        Invoke("JumpScareMethod", Random.Range(5, 11));
    }
    private void JumpScareMethod()
    {
        an.SetBool("jumpScare", true);
        jumpScareImage.SetActive(true);
        jumpScareSound.Play();
    }
}
