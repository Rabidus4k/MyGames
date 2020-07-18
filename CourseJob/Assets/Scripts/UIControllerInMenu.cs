using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControllerInMenu : MonoBehaviour
{
    public GameObject _Info;
    public GameObject _LeaderBoard;

    public void Start_Clicked()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit(0);
    }


    public void Show_Info()
    {
        _Info.SetActive(true);
    }

    public void Hide_Info()
    {
        _Info.SetActive(false);
    }

    public void Show_LeaderBoard()
    {
        _LeaderBoard.SetActive(true);
    }

    public void Hide_LeaderBoard()
    {
        _LeaderBoard.SetActive(false);
    }
}
