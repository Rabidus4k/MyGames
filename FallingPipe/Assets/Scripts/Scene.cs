using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    public ParticleSystem ps;


    


    public GameObject gameOver;
    public GameObject controlls;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public Slider mainSlider;

    public Text hightTextScore;
    public Text difficulty;
    [SerializeField] private Text _fpsText;
    [SerializeField] private float _hudRefreshRate = 1f;

    private void Start()
    {
        Time.timeScale = 1;

        Enum.hightScore = 0;
        Enum.isDead = false;
        Enum.isPlayed = false;
        Enum.globalSpeed = 20;
        Enum.score = 0;

        gameOver.SetActive(false);
        controlls.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void reloadLevel()
    {
        Time.timeScale = 1;
        Enum.isDead = false;
        Enum.isPlayed = false;
        Enum.globalSpeed = 20;
        Enum.score = 0;

        gameOver.SetActive(false);
        controlls.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void God()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Vector3 spawnPos = new Vector3();
        spawnPos.x = player.transform.position.x;
        spawnPos.y = player.transform.position.y * (-1);
        spawnPos.z = player.transform.position.z;

        player.transform.position = spawnPos;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Difficulty()
    {
        Enum.enemiesToSpawn = (int)mainSlider.value;
        difficulty.text = "Кол-во кактусов : " + Enum.enemiesToSpawn;
    }

    public void Settings() 
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void onPause()
    {
        if (!Enum.isDead)
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                settingsMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
        }
    }

    private float _timer;
    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }

    private void FixedUpdate()
    {
        if (Enum.isDead)
        {
            Time.timeScale = 0;

            gameOver.SetActive(true);
            controlls.SetActive(false);
        }

        if (Enum.score > Enum.hightScore)
        {
            if (!Enum.isPlayed )
            {
                ps.Play();
                Enum.isPlayed = true;
            }
            
            Enum.hightScore = Enum.score;
            hightTextScore.text = "HI: " + Enum.hightScore;
        }
    }
}
