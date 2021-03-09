using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    ParticleSystem pS;
    Transform bulletPos;
    public GameObject bullet;
    float bulletSpeed = 200;
    Vector3 rayHit;
    RaycastHit hit;
    private Animator an;
    private AudioSource aS;
    public int ammo = 0;
    public int maxAmmo = 5;
    public Text text;
    //public CameraShake shake;

    private void Start()
    {
        pS = transform.GetChild(4).GetComponent<ParticleSystem>();
        bulletPos = transform.GetChild(3).GetComponent<Transform>();
        an = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
    }
    public void Shoot(Vector3 rayOrigin, Camera cam)
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            pS.Play();

            var iBullet = Instantiate(bullet, bulletPos.position, FindObjectOfType<Player>().transform.rotation) as GameObject;

            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit))
            {
                rayHit = hit.point;
            }

            iBullet.GetComponent<Rigidbody>().velocity = (rayHit - bulletPos.position).normalized * bulletSpeed;
            aS.Play();
            an.SetTrigger("shoot");
            ammo--;
            //StartCoroutine(shake.ShakeCamera(0.1f, 0.1f));
        }
    }

    private void Update()
    {
        text.text = ammo.ToString() + "/" + maxAmmo.ToString();
    }

    public void IncreaseAmmo()
    {
        if(ammo < maxAmmo)
        {
            ammo++;
        }
    }
}
