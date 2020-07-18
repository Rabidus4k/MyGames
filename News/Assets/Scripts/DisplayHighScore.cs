using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    public Text[] m_highscoreFieldsText;

    private LeaderBoard m_highscoresManager;
    private static DisplayHighScore m_instance;

    void Start()
    {
        m_instance = this;
        for (int i = 0; i < m_highscoreFieldsText.Length; i++)
        {
            m_highscoreFieldsText[i].text = i + 1 + ". Loading...";
        }

        m_highscoresManager = GetComponent<LeaderBoard>();
        RefreshHighscores();
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < m_highscoreFieldsText.Length; i++)
        {
            m_highscoreFieldsText[i].text = i + 1 + ". ";
            if (i < highscoreList.Length)
            {
                m_highscoreFieldsText[i].text += highscoreList[i].username + " | " + highscoreList[i].score;
            }
        }
    }


    public static void RefreshHighscores()
    {
        Debug.Log("Downloading leaderboard");
        m_instance.m_highscoresManager.DownloadHighscores();
    }
}
