using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SaveScore : MonoBehaviour
{
    private int _HighScore;
    public TextMeshProUGUI _HighScoreText;

    void Start()
    {
        _HighScore = PlayerPrefs.GetInt("Score");
        _HighScoreText.SetText(_HighScore.ToString());
    }
    
    /// <summary>
    /// Сохранение нового результата
    /// </summary>
    /// <param name="newScore">новый полученный результат</param>
    public void SaveNewScore(int newScore)
    {
        if (newScore > _HighScore)
        {
            _HighScore = newScore;
            _HighScoreText.SetText(_HighScore.ToString());
            PlayerPrefs.SetInt("Score", _HighScore); 
        }
    }
}
