using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class NickNameSetter : MonoBehaviour
{
    public TextMeshPro m_NickNameText;

    private PhotonView m_PhotonView;

    private void Start()
    {
        m_PhotonView = GetComponent<PhotonView>();
        m_NickNameText.SetText(m_PhotonView.Owner.NickName);

        if (m_PhotonView.IsMine)
        {
            m_NickNameText.color = new Color(238, 186, 0);
        }
        
    }
}
