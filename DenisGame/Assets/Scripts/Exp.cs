using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Exp : MonoBehaviour
{
    public GameObject expBar;
    public GameObject ChooseGun;
    private float expCount = 0;
    private int currentLevel = 1;
    public int points = 1;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText;
    public GameObject levelUp;
    public int Score = 0;
    private PlayerController playerController;
    public TextMeshProUGUI pointsText;
    private void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
    }
    private void FixedUpdate()
    {
        expCount += 0.001f/currentLevel;
        SetSize();
    }



    public void GetExp(float expGot)
    {
        expCount += expGot / (100f * currentLevel);
    }
    private void SetSize()
    {
        if (expCount >= 1)
        {
            Score += 100;
            scoreText.SetText($"SCORE: {Score}");
            expCount = 0;
            currentLevel++;
            points++;
            SetPointsText();
            ShowLevelUp();
            levelText.SetText($"LVL: {currentLevel}");

            if (currentLevel % 5 == 0)
            {
                ChooseGun.SetActive(true);
            }
        }
        expBar.transform.localScale = new Vector3(expCount, 1, 1);
    }

    public void UsePoint()
    {
        points--;
        SetPointsText();
        if (points == 0)
        {
            HileLevelUp();
        }
    }

    public void GetPoints(int number)
    {
        points += number;
        ShowLevelUp();
        SetPointsText();
    }

    private void SetPointsText()
    {
        pointsText.SetText($"POINTS: {points}");
    }

    public void HileLevelUp()
    {
        levelUp.SetActive(false);
    }
    public void ShowLevelUp()
    {
        levelUp.SetActive(true);
    }

    public void GetSpeedPlus(GameObject bar)
    {
        if (bar.transform.localScale.x + 0.2f <= 1.1f)
        {
            UsePoint();
            bar.transform.localScale = new Vector3(bar.transform.localScale.x + 0.2f, 1, 1);
            playerController.Speed++;
        }
    }

    public void GetDamagePlus(GameObject bar)
    {
        if (bar.transform.localScale.x + 0.1f <= 1.1f)
        {
            UsePoint();
            bar.transform.localScale = new Vector3(bar.transform.localScale.x + 0.1f, 1, 1);
            playerController.Damage+= 10;
        }
    }

    public void GetBulletSpeedPlus(GameObject bar)
    {
        if (bar.transform.localScale.x + 0.2f <= 1.1f)
        {
            UsePoint();
            bar.transform.localScale = new Vector3(bar.transform.localScale.x + 0.2f, 1, 1);
            playerController.BulletSpeed += 5;
        }
    }

    public void GetShootChancePlus(GameObject bar)
    {
        if (bar.transform.localScale.x + 0.2f <= 1.1f)
        {
            UsePoint();
            bar.transform.localScale = new Vector3(bar.transform.localScale.x + 0.2f, 1, 1);
            playerController.ShootChance += 20;
        }
    }

    public void GetReloadPlus(GameObject bar)
    {
        if (bar.transform.localScale.x + 0.2f <= 1.1f)
        {
            UsePoint();
            bar.transform.localScale = new Vector3(bar.transform.localScale.x + 0.2f, 1, 1);
            playerController.ReloadSpeed *= 1.5f;
        }
    }

    public void GetBulletLifeTimePlus(GameObject bar)
    {
        if (bar.transform.localScale.x + 0.2f <= 1.1f)
        {
            UsePoint();
            bar.transform.localScale = new Vector3(bar.transform.localScale.x + 0.2f, 1, 1);
            playerController.BulletLifeTime *= 1.5f ;
        }
    }
}
