using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
