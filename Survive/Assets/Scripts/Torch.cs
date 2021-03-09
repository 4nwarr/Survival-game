using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Photon.MonoBehaviour
{
    public PhotonView photonView;
    bool torchIsActive = false;
    [SerializeField] GameObject torchLight;
    AudioSource aS;
    private Animator animator;
    public Camera cam;

    private void Start()
    {
        if (photonView.isMine)
        {
            torchIsActive = false;
            aS = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
        }
    }
    public void ActivateDisactivateTorch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (torchIsActive)
            {
                torchIsActive = false;
                torchLight.SetActive(false);
            }
            else if (!torchIsActive)
            {
                torchIsActive = true;
                torchLight.SetActive(true);
            }
            aS.Play();
            animator.SetBool("isActive", torchIsActive);
        }
    }
}
