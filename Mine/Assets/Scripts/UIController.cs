using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private static UIController m_instance;

    [SerializeField] private GameObject m_leaderBoardUI;
    [SerializeField] private GameObject m_mainUI;
    [SerializeField] private GameObject m_pauseUI;
    [SerializeField] private GameObject m_settingsUI;
    [SerializeField] private GameObject m_exitUI;
    [SerializeField] private GameObject m_creditsUI;
    private PhotonView photonView;
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        m_instance = this;

        m_leaderBoardUI.SetActive(false);
        m_mainUI.SetActive(true);
        m_pauseUI.SetActive(false);
        m_settingsUI.SetActive(false);
        m_exitUI.SetActive(false);
        m_creditsUI.SetActive(false);
    }

    public static void ShowPause()
    {
        m_instance.ShowPauseUI();
    }
    public static void HidePause()
    {
        m_instance.ShowMenuUI();
    }

    public void ShowMenuUI()
    {
        SetActiveUI(false, true, false, false, false, false);
    }

    public void ShowPauseUI()
    {
        SetActiveUI(false, false, true, false, false, false);
    }

    public void ShowCreditsUI()
    {
        SetActiveUI(false, false, false, false, false, true);
    }

    public void ShowLeaderBoardUI()
    {
        SetActiveUI(true, false, false, false, false, false);
    }

    public void ShowSettingsUI()
    {
        SetActiveUI(false, false, false, true, false, false);
    }

    public void ShowExitUI()
    {
        SetActiveUI(false, false, false, false, true, false);
    }

    public void Exit()
    {
        //
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
        
    }

    private void SetActiveUI(bool a1, bool a2, bool a3, bool a4, bool a5, bool a6)
    {
        m_leaderBoardUI.SetActive(a1);
        m_mainUI.SetActive(a2);
        m_pauseUI.SetActive(a3);
        m_settingsUI.SetActive(a4);
        m_exitUI.SetActive(a5);
        m_creditsUI.SetActive(a6);
    }
}
