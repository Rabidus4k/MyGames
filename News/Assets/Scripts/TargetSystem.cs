using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class TargetSystem : MonoBehaviourPunCallbacks
{
    private GameObject[] playersInGame = { };
    private TextMeshProUGUI m_targetName;
    private List<string> playersNamesInGame = new List<string>();
    private int curPlayer;
    public GameObject m_arrow;
    public bool m_findAllPlayers = false;
    private GameObject currentTarget;
    public GameObject Target { get { return currentTarget; } }

    private void Start()
    {
        m_arrow = GameObject.FindGameObjectWithTag("Arrow");
        curPlayer = 0;
        StartCheck();
    }

    public void ChangeTarget()
    {
        if (curPlayer > playersNamesInGame.Count - 1)
        {
            curPlayer = 0;
        }

        if (curPlayer < 0)
        {
            curPlayer = playersNamesInGame.Count - 1;
        }
        currentTarget = playersInGame[curPlayer];
        m_arrow.transform.parent = currentTarget.transform;
        m_arrow.transform.position = currentTarget.transform.position;
        m_targetName.SetText($"TARGET: {playersNamesInGame[curPlayer]}");
    }

    public void PrevPlayer()
    {
        curPlayer--;
        ChangeTarget();
    }

    public void NextPlayer()
    {
        curPlayer++;
        ChangeTarget();
    }

    public void Reload()
    {
        StartCheck();
    }

    private void StartCheck()
    {
        playersNamesInGame.Clear();

        playersInGame = GameObject.FindGameObjectsWithTag("Player");
        if (playersInGame.Length != 0)
        {
            foreach (GameObject player in playersInGame)
            {
                var playerName = player.GetComponent<PhotonView>().Owner.NickName;
                playersNamesInGame.Add(playerName);
            }
            curPlayer = 0;
            currentTarget = playersInGame[curPlayer];
            m_arrow.transform.parent = currentTarget.transform;
            m_arrow.transform.position = currentTarget.transform.position;
            m_targetName = GameObject.FindGameObjectWithTag("Target").GetComponent<TextMeshProUGUI>();
            m_targetName.SetText($"TARGET: {playersNamesInGame[curPlayer]}");
        }
    }
}
