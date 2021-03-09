﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwitchWeapons : Photon.MonoBehaviour
{
    public int currentWeapon = 0;
    public Camera cam;
    public PhotonView photonView;
    void Start()
    {
        if (photonView.isMine)
        {
            SwitchWeapon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine)
        {
            int oldCurrentWeapon = currentWeapon;
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (currentWeapon >= transform.childCount - 1)
                {
                    currentWeapon = 0;
                }
                else
                {
                    currentWeapon++;
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (currentWeapon <= 0)
                {
                    currentWeapon = transform.childCount - 1;
                }
                else
                {
                    currentWeapon--;
                }
            }

            if (currentWeapon != oldCurrentWeapon)
            {
                SwitchWeapon();
            }

            this.gameObject.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
        }
    }

    private void SwitchWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if( i == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
