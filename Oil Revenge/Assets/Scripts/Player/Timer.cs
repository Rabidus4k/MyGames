using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timer = 90;
    public DateTime timeSpend;
    private DateTime timerEnd;

    private void Start()
    {
        timerEnd = DateTime.Now.AddSeconds(timer);
    }

    private void Update()
    {
        TimeSpan delta = timerEnd - DateTime.Now;
        timerText.text = (delta.Minutes.ToString("00") + ":" + delta.Seconds.ToString("00"));
        timeSpend.AddSeconds(1);
        if (delta.TotalSeconds <= 0)
        {
            //SceneManager.LoadScene("DieScene");
        }

    }
}