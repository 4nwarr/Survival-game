using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Photon.MonoBehaviour
{
    private Animator an;
    private AudioSource aS;
    public GameObject lights;
    public bool canBlackOut = true;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        an = GetComponent<Animator>();
    }

    public void RPCButton(){
        photonView.RPC("TriggerButton", PhotonTargets.All);
    }

    [PunRPC]
    public void TriggerButton()
    {
        FindObjectOfType<Player>().lightIsActive = true;
        lights.SetActive(true);
        an.SetTrigger("button");
        AudioSource.PlayClipAtPoint(aS.clip, transform.position, 1);
        Invoke("LightCooldown", 30);
    }

    private void LightCooldown()
    {
        canBlackOut = true;
    }
}
