using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmos : MonoBehaviour
{
    public GameObject ammo;
    public Transform[] wayPoints;
    public bool[] spawned;

    void Start()
    {
        SpawnAmmo();
    }
    void Update()
    {
    }

    private void SpawnAmmo()
    {
        int x;
        int counter = 0;

        do
        {
            x = Random.Range(0, wayPoints.Length); //wayPoints = vettore di wayPoint
        }
        while (spawned[x] && counter > wayPoints.Length); //spawned = vettore di boolean 

        if (!spawned[x])
        {
            var iAmmo = Instantiate(ammo, wayPoints[x].position, Quaternion.identity) as GameObject; //spawn proiettile
            iAmmo.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
        }

        spawned[x] = true; 
        counter++;

        Invoke("SpawnAmmo", 20); //Richiama se stesso il loop ogni 5 secondi
    }
}
