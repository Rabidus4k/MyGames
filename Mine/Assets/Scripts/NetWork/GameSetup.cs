using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class GameSetup : MonoBehaviour
{
    private GameObject spawnPoint;
    void Awake()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("StartGamePoint");
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating player");
        
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), spawnPoint.transform.position, Quaternion.identity);
       
    }
}
