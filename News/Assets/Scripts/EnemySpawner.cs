using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private GameObject[] m_SpawnPoints;
    private float m_SpawnRate;

    private void Start()
    {
        m_SpawnRate = 2f;
        StartGame();
        m_SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    public void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine("DoCheck");
            StartCoroutine("RateIncrease");
        }
    }

    IEnumerator RateIncrease()
    {    
        yield return new WaitForSeconds(10f);
        if (m_SpawnRate >= 0.06f)
            m_SpawnRate -= 0.05f;
        StartCoroutine("RateIncrease");
    }

    IEnumerator DoCheck()
    {
        yield return new WaitForSeconds(m_SpawnRate);
        GameObject tempEnemy = PhotonNetwork.Instantiate
            (
                Path.Combine("PhotonPrefabs", "Enemy"),
                m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)].transform.position,
                Quaternion.identity
            );
        
        Destroy(tempEnemy, 5f);
        StartCoroutine("DoCheck");
    }
}
