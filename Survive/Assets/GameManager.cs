using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(this.player.name, new Vector3(0, 2.5f, 0), Quaternion.identity, 0);
        Debug.Log("Giocatore Instanziato");
    }


}
