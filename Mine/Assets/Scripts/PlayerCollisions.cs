using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class PlayerCollisions : MonoBehaviour
{
    private Text hintText;

    private int isCarringItem = 0;

    private PlayerStats m_playerStats;
    private PlayerTorch m_playerTorch;
    private CartMovement m_cartMovement;
    private PathBuilder m_pathBuilder;
    private GoldManager m_goldManager;
    private GameManager m_gameManager;

    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        

        m_playerStats = gameObject.GetComponent<PlayerStats>();
        m_playerTorch = gameObject.GetComponent<PlayerTorch>();
        m_goldManager = gameObject.GetComponent<GoldManager>();

        hintText = GameObject.FindGameObjectWithTag("HintTextUI").GetComponent<Text>();
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        m_cartMovement = GameObject.FindGameObjectWithTag("Cart").GetComponent<CartMovement>();
        m_pathBuilder = GameObject.FindGameObjectWithTag("Game").GetComponent<PathBuilder>();

        hintText.text = "";
    }


    #region COLLISION
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (photonView == null)
        {
            photonView = GetComponent<PhotonView>();
        }

        if (photonView.IsMine) { 
            if (collision.gameObject.CompareTag("Cart"))
            {
                switch (isCarringItem)
                {
                    case 1:
                        m_goldManager.GetGold(100);
                        isCarringItem = 0;
                        break;

                    case 2:
                        m_goldManager.GetGold(500);
                        isCarringItem = 0;
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (photonView == null)
        {
            photonView = GetComponent<PhotonView>();
        }
        if (photonView.IsMine)
        {
            if (other.gameObject.CompareTag("Torch"))
            {
                hintText.text = "PRESS 'E' TO TAKE TORCH";
            }

            if (other.gameObject.CompareTag("Exit"))
            {
                m_gameManager.EnterLobby(gameObject);

            }
            if (other.gameObject.CompareTag("Start"))
            {
                m_gameManager.ExitLobby(gameObject);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (photonView.IsMine)
        {
            if (other.gameObject.CompareTag("Torch"))
            {
                hintText.text = "";
            }


            if (other.gameObject.CompareTag("DeathZone"))
            {
                m_playerStats.Heal();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (Input.GetKey(KeyCode.E))
        {
            //if (other.gameObject.CompareTag("Torch"))
            //{
            //    m_playerTorch.TakeTorch(other.gameObject);
            //}

            if (other.gameObject.CompareTag("Gold") && isCarringItem == 0)
            {
                isCarringItem = 1;
                PhotonNetwork.Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("Diamond") && isCarringItem == 0)
            {
                isCarringItem = 2;
                PhotonNetwork.Destroy(other.gameObject);
            }
            if (PhotonNetwork.IsMasterClient)
            {
                if (other.gameObject.CompareTag("InfoTableStart"))
                {
                    m_cartMovement.SetCartSpeed(Settings.STATRCARTSPEED);
                    m_pathBuilder.StartBuild();
                }
            }
        }

        if (photonView.IsMine)
        {
            if (other.gameObject.CompareTag("DeathZone"))
            {
                m_playerStats.GetDamage();
            }
        }
    }
    #endregion
}
