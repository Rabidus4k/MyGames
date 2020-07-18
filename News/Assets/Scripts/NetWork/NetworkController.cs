using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public Text log;

    private void Start()
    {
        
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are conneted to " + PhotonNetwork.CloudRegion);
        log.text = "We are conneted to " + PhotonNetwork.CloudRegion;
        
    }
    
}
