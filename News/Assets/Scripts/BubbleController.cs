using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour, IPunObservable
{
    [SerializeField] private GameObject m_BubbleGameObject;

    private bool m_IsActive;
    private int m_TargetId = -1;
    
    private void Start()
    {
        m_IsActive = false;      
    }

    private void FixedUpdate()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject i in players)
        {
            if (i.GetComponent<PhotonView>().ViewID == m_TargetId)
            {
                i.GetComponent<BubbleController>().m_BubbleGameObject.SetActive(m_IsActive);
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        m_IsActive = false;
    }

    public void ActivateBubble(int id)
    {
        m_TargetId = id;
        m_IsActive = true;
        StartCoroutine("Wait");
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //stream.SendNext(m_TargetId);
            //stream.SendNext(m_IsActive);
        }
        else
        {
            //m_TargetId = (int)stream.ReceiveNext();
            //m_IsActive = (bool)stream.ReceiveNext();
        }
    }
}
