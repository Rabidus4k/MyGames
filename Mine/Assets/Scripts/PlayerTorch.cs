using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerTorch : MonoBehaviour
{
    [SerializeField] private int m_ammounOfTorches = 5;

    public void PlaceTorch()
    {
        if (m_ammounOfTorches > 0)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonTorch"), transform.position, Quaternion.identity);
            m_ammounOfTorches--;
        }
    }

    public void TakeTorch(GameObject torch)
    {
        int tempRandInt = Random.Range(0, 100);
        PhotonNetwork.Destroy(torch);
        if (tempRandInt >= Settings.CHANCE)
        {
            m_ammounOfTorches++;
        }
    }
}
