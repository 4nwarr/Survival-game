using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Role
{
    Killer,
    Survivor
}
public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Camera cam;
    Vector3 rayOrigin;
    public GameObject gun, knife, globalLight, ammoCounter;
    RaycastHit hit;
    public Role role;
    private SwitchWeapons sW;
    public float range = 5;
    public bool lightIsActive = true;
    private bool canBlackOut = true;
    public AudioSource aS, pick;
    public GameObject lights;
    public GameObject eyes;
    public GameObject button;

    void Start()
    {
        if (photonView.isMine)
        {
            int x = Random.Range(0, 2);
            switch (x)
            {
                case 0: //Killer
                    role = Role.Killer;
                    GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case 1: //Survivor
                    role = Role.Survivor;
                    GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(2).gameObject.SetActive(true);
                    Destroy(knife);
                    break;
            }

            eyes.SetActive(false);

            sW = FindObjectOfType<SwitchWeapons>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.isMine)
        {
            rayOrigin = cam.ViewportToWorldPoint(new Vector3(05f, 05f, 0));

            switch (role)
            {
                case Role.Killer:
                    BlackOut();
                    break;
                case Role.Survivor:
                    break;
            }

            switch (sW.currentWeapon)
            {
                case 0:
                    FindObjectOfType<Gun>().Shoot(rayOrigin, cam);
                    ammoCounter.SetActive(true);
                    break;
                case 1:
                    FindObjectOfType<Torch>().ActivateDisactivateTorch();
                    ammoCounter.SetActive(false);
                    break;
                case 2:
                    FindObjectOfType<Knife>().Attack();
                    ammoCounter.SetActive(false);
                    break;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, range))
                {
                    GameObject myGO = hit.collider.gameObject;

                    if (myGO.CompareTag("FrontCollider"))
                    {
                        myGO.transform.GetComponentInParent<Door>().OpenDoor(1);
                    }

                    if (myGO.CompareTag("BackCollider"))
                    {
                        myGO.transform.GetComponentInParent<Door>().OpenDoor(0);
                    }

                    if (myGO.CompareTag("Ammo"))
                    {
                        gun.GetComponent<Gun>().IncreaseAmmo();
                        Destroy(myGO.gameObject);
                        pick.Play();
                    }

                    if (myGO.CompareTag("Button"))
                    {
                        button.GetComponent<Button>().RPCButton();
                    }
                }
            }
        }
    }

    private void BlackOut()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            photonView.RPC("TestBalckOut", PhotonTargets.All);
        }
    }

    [PunRPC]
    private void TestBalckOut()
    {
        if (lightIsActive && (FindObjectOfType<Button>().canBlackOut == true))
            {
                FindObjectOfType<Button>().canBlackOut = false;
                lightIsActive = false;
                GameObject.FindGameObjectWithTag("Lights").SetActive(false);
                aS.Play();
            }
    }

    /*
    private void Pick()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(rayOrigin, cam.transform.forward, out hit))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.gameObject.CompareTag("Gun"))
            {
                gun.transform.localPosition = gunContainer.position;
                gun.transform.parent = gunContainer.transform.parent;
                isPicked = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.rotation = gunContainer.rotation;
            }
        }
    }

    private void Drop()
    {
        if(isPicked && Input.GetKeyDown(KeyCode.Q))
        {
            gun.transform.parent = null;
            gun.GetComponent<Rigidbody>().isKinematic = false;
            gun.GetComponent<Rigidbody>().AddForce(Vector3.up + cam.transform.forward * trowGun, ForceMode.Impulse);
            Invoke("StopGun", 1);
            isPicked = false;
        }
    }

    private void StopGun()
    {
        gun.GetComponent<Rigidbody>().isKinematic = true;
    }
        */ //Pick and drop gun 
}
