using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_playerSpeed = 5f;
    private PlayerTorch m_playerTorch;
    private PhotonView photonView;
    public GameObject cam;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        m_playerTorch = gameObject.GetComponent<PlayerTorch>();
    }
    
    private void Update()
    {      
        if (photonView.IsMine) {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * (m_playerSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * (m_playerSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * (m_playerSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * (m_playerSpeed * Time.deltaTime));
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIController.ShowPause();
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_playerTorch.PlaceTorch();
            }
        } else
        {
            cam.SetActive(false);
        }
        
    }
}
