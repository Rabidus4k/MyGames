using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    public GameObject WindowsGoodMessage;
    public AudioSource audio;
    public static FinishController inst;
    private void Start()
    {
        inst = this;
    }

    public static void Show()
    {
        inst.audio.Play();
        inst.WindowsGoodMessage.SetActive(true);
    }
    public void OnOk()
    {
        SceneManager.LoadScene(1);
    }
}
