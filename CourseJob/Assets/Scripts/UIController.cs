using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI _Radius;
    public TextMeshProUGUI _Time;
    public PlanetSizer _PlanetSizer;
    public GameObject _StartMenu;
    public GameObject _PauseMenu;
    public GameObject _Info;
    public SaveScore _SaveScore;

    public MeteorGenerator MeteorGenerator;
    public Movement Movement;
    public CameraMovement CameraMovement;
    public PlanetSizer PlanetSizer;

    private bool _OnPause;
    private bool _GameStarted = false;

    public void Start()
    {
        Time.timeScale = 1;
        _OnPause = false;
        _GameStarted = false;
    }
    public void Menu_Clicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        Time.timeScale = 1;
        _SaveScore.SaveNewScore(100 - (int)(_PlanetSizer._Size * 100));
        SceneManager.LoadScene(1);
    }
    public void Test()
    {
        PlayerPrefs.SetInt("Score", 0);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        _GameStarted = true;

        MeteorGenerator.enabled = true;
        Movement.enabled = true;
        CameraMovement.enabled = true;
        PlanetSizer.enabled = true;

        _Info.SetActive(true);
        _StartMenu.SetActive(false);
    }

    public void PauseGame()
    {
        _PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        _Radius.SetText(((int)(_PlanetSizer._Size * 100)).ToString() + " m.");

        if (_GameStarted && Input.GetKeyDown(KeyCode.Escape))
        {
            if (_OnPause)
            {
                ResumeGame();
                _OnPause = !_OnPause;
            }
            else
            {
                PauseGame();
                _OnPause = !_OnPause;
            }
            
        }
    }
}
