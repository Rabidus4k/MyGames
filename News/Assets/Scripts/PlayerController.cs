using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class PlayerController : MonoBehaviour, IPunObservable
{
    public bool isDead = false;

    private PhotonView m_photonView;

    private BubbleController m_bubble;
    //private TargetSystem m_targetSyst;
    private UIController m_uIController;
    private PlayerMovement m_playerMovement;


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(isDead);
        }
        else
        {
            isDead = (bool)stream.ReceiveNext();
        }
    }

    private void Start()
    {
        isDead = false;
        m_photonView = gameObject.GetComponent<PhotonView>();
        m_playerMovement = gameObject.GetComponent<PlayerMovement>();
        m_bubble = gameObject.GetComponent<BubbleController>();
        //m_targetSyst = GameObject.FindGameObjectWithTag("TargetSystem").GetComponent<TargetSystem>();
        m_uIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            StartCoroutine("Wait");
        }
    }

    private void Update()
    {
        if (m_photonView.IsMine) { 
            if (Input.GetKeyDown(KeyCode.Space) && StrengthBarController.m_strength >= 0.4f)
            {
                m_playerMovement.Jump();
                StrengthBarController.LowStrength(0.5f);
            }
        
            if (Input.GetKeyDown(KeyCode.F) && StrengthBarController.m_strength >= 0.4f)
            {
                //GameObject tempTarget = m_targetSyst.Target;
                //m_bubble.ActivateBubble(tempTarget.GetComponent<PhotonView>().ViewID);
                m_bubble.ActivateBubble(m_photonView.ViewID);
                StrengthBarController.LowStrength(0.5f);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                //m_targetSyst.PrevPlayer();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                //m_targetSyst.NextPlayer();
            }
            if (Input.GetKey(KeyCode.LeftShift) )
            {
                m_playerMovement.Speed = 15f;
                StrengthBarController.LowStrength(0.005f);
            }
            else
            {
                m_playerMovement.Speed = 10f;
            }
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "DeadZone" || collision.gameObject.tag == "Enemy"))
        {
            if (m_photonView.IsMine)
            {
                isDead = true;
                LeaderBoard.AddNewHighscore(PhotonNetwork.NickName, Score.m_score);
                //m_targetSyst.m_arrow.SetActive(true);
                //m_targetSyst.Reload();
                
                m_uIController.m_deathUI.SetActive(true);
            }
        }
    }
}
