using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private GameObject m_CreditsUI;
    [SerializeField] private GameObject m_SettingsUI;

    private void Start()
    {
        m_CreditsUI.SetActive(false);
        m_SettingsUI.SetActive(false);
    }

    public void OnQuitClicked()
    {
        Application.Quit(0);
    }

    public void OnCreditsClicked()
    {
        m_CreditsUI.SetActive(true);
    }

    public void OnCreditsExitClicked()
    {
        m_CreditsUI.SetActive(false);
    }

    public void OnSettingsClicked()
    {
        m_SettingsUI.SetActive(true);
    }

    public void OnSettingsExitClicked()
    {
        m_SettingsUI.SetActive(false);
    }

    public void OnStartGameClicked()
    {
        SceneManager.LoadScene(1);
    }
}
