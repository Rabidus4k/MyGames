using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    const string privateCode = "bdx7CX8NNUStb297XDOxGQy9OndIcmCUeU7IfxkHXvhw";
    const string publicCode = "5e5291d0fe232612b85af1f0";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] m_highscoresList;

    private static LeaderBoard instance;
    private DisplayHighScore m_highscoreDisplay;

    private void Awake()
    {
        instance = this;
        m_highscoreDisplay = GetComponent<DisplayHighScore>();
    }

    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            DownloadHighscores();
        }
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    private void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        m_highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            m_highscoresList[i] = new Highscore(username, score);
            print(m_highscoresList[i].username + ": " + m_highscoresList[i].score);
        }
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/0/10");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            m_highscoreDisplay.OnHighscoresDownloaded(m_highscoresList);
        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }
}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }

}