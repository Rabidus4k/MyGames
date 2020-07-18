using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _GameOver;
    public GameObject Info;
    public TextMeshProUGUI InfoText;
    public TextMeshProUGUI MaxScoreText;
    private static UIController inst;
    public void Start()
    {
        Time.timeScale = 1f;
        MaxScoreText.SetText($"HIGH SCORE:\n {PlayerPrefs.GetInt("Score")}");
        inst = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public static void GameOver()
    {
        Time.timeScale = 0f;
        inst._GameOver.SetActive(true);
        int tempScore = GameObject.FindGameObjectWithTag("Player").GetComponent<Exp>().Score;
        if (tempScore > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", tempScore);
            inst.MaxScoreText.SetText($"HIGH SCORE: {tempScore}");
        }
    }


    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowInfo(int num)
    {
        Info.SetActive(true);
        Time.timeScale = 0f;

        switch (num)
        {
            case 0:
                InfoText.SetText("Выбрав это улучшение, вы навесегда получите:\n " +
                    "+20% к скорости\n" +
                    "Перегрев снизится до минимума\n" +
                    "-----------\n" +
                    "-30% к шансу прострела\n");
                break;
            case 1:
                InfoText.SetText("Выбрав это улучшение, вы навесегда получите:\n " +
                    "+20% к шансу прострела\n" +
                    "Перегрев снизится до минимума\n" +
                    "-----------\n" +
                    "-20% к урону\n" +
                    "-20% к скорости бега\n");
                break;
            case 2:
                InfoText.SetText("Выбрав это улучшение, вы навесегда получите:\n " +
                    "+100% к скорости полёта пули\n" +
                    "+100% к урону\n" +
                    "-----------\n" +
                    "-40% к скорости бега\n" +
                    "Выстрел перегревает оружее на половину\n");
                break;
            case 3:
                InfoText.SetText("Выбрав это улучшение, вы навесегда получите:\n " +
                    "5 бонусных очков\n" +
                    "-----------\n" +
                    "Вам достанется одно из оружий со всеми эффектами случайным образом\n");
                return;
            default:
                break;
        }
    }

    public void CloseInfo()
    {
        Info.SetActive(false);
        Time.timeScale = 1f;
    }
}
