using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject m_leaderBoardUI;
    [SerializeField] public GameObject m_menuUI;
    [SerializeField] private GameObject m_helpUI;
    [SerializeField] public GameObject m_deathUI;
    [SerializeField] private GameObject m_restartUI;
    [SerializeField] private GameObject m_settingsUI;

    [SerializeField] private GameObject m_postProcessing;

    private int countOfPlayers;

    bool inMenu = false;

    private void Start()
    {
        m_leaderBoardUI.SetActive(false);
        m_menuUI.SetActive(false);
        m_deathUI.SetActive(false);
    }

    private void Update()
    {
        countOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;

        if (countOfPlayers == 0 && PhotonNetwork.IsMasterClient)
        {
            m_restartUI.SetActive(true);
        }
       
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            DisplayHighScore.RefreshHighscores();
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            m_leaderBoardUI.SetActive(true);
        }
        else
        {
            m_leaderBoardUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!inMenu)
            {
                m_menuUI.SetActive(true);
                inMenu = true;
            }
            else
            {
                m_menuUI.SetActive(false);
                m_settingsUI.SetActive(false);
                m_helpUI.SetActive(false);
                m_leaderBoardUI.SetActive(false);
                inMenu = false;
            }
        }
    }

    public void RestartOnClick()
    {
        PhotonNetwork.LoadLevel(1); //TODO : Fix
    }

    public void ResumeOnClicked()
    {
        m_helpUI.SetActive(false);
        m_menuUI.SetActive(false);
        inMenu = false;
    }

    public void ShowHelpOnClicked()
    {
        m_helpUI.SetActive(true);
        m_menuUI.SetActive(false);
    }

    public void CloseHelpOnClicked()
    {
        m_helpUI.SetActive(false);
        inMenu = false;
    }


    public void ShowDeathUI()
    {
        m_deathUI.SetActive(false);
    }

    public void ShowSettingsOnClicked()
    {
        m_settingsUI.SetActive(true);
        m_menuUI.SetActive(false);
    }

    public void CloseSettingsOnClicked()
    {
        m_settingsUI.SetActive(false);
        inMenu = false;
    }

    public void SetGraphicsHighOnClicked()
    {
        m_postProcessing.SetActive(true);
    }

    public void SetGraphicsLowOnClicked()
    {
        m_postProcessing.SetActive(false);
    }

    public void ExitOnClicked()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene(0);
    }
}
