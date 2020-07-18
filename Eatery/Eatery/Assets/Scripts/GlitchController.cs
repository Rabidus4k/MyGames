using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlitchController : MonoBehaviour
{
    [SerializeField]
    private DigitalGlitch   _digitalGlitch;
    [SerializeField]
    private AnalogGlitch    _analogGlitch;
    [SerializeField]
    private GameObject      _backGround;

    public AudioSource audio;
    public AudioSource music;
    public AudioSource horrormusic;
    [SerializeField]
    private GameObject _normalScene;
    [SerializeField]
    private GameObject _bloodyScene;
    [SerializeField]
    private GameObject _normalPovar;
    [SerializeField]
    private GameObject _bloodyPovar;

    [SerializeField]
    private GameObject _FoodController;
    [SerializeField]
    private GameObject _Dialogue;
    [SerializeField]
    private GameObject _Door;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void GlitchCamera()
    {
        StartCoroutine("Glitch");
    }

    public void Start()
    {
        StartCoroutine(Cicle(25f));
    }

    private IEnumerator Cicle(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        StartCoroutine("Glitch");

        if (time > 0.5f)
            StartCoroutine(Cicle(time * 0.6f));
        else
        {
            StopAllCoroutines();
            ChangeScene();
        }
            
    }

    private void ChangeScene()
    {
        StartCoroutine("LastGlitch");

        _Dialogue.SetActive(true);
        _Door.GetComponent<Animator>().Play("Door_Open");
    }

    private IEnumerator Glitch()
    {
       
        _digitalGlitch.enabled = true;
        _analogGlitch.enabled = true;
        _backGround.SetActive(true);

        _normalScene.SetActive(false);
        _normalPovar.SetActive(false);
        _bloodyScene.SetActive(true);
        _bloodyPovar.SetActive(true);
        audio.enabled = true;
        music.enabled = false;
        yield return new WaitForSeconds(0.8f);

        _digitalGlitch.enabled = false;
        _analogGlitch.enabled = false;
        _backGround.SetActive(false);


        _normalScene.SetActive(true);
        _normalPovar.SetActive(true);
        _bloodyScene.SetActive(false);
        _bloodyPovar.SetActive(false); 
        audio.enabled = false; 
        music.enabled = true;
    }

    private IEnumerator LastGlitch()
    {
        audio.enabled = true;
        _digitalGlitch.enabled = true;
        _analogGlitch.enabled = true;
        _backGround.SetActive(true);

        _normalScene.SetActive(false);
        _normalPovar.SetActive(false);
        _bloodyScene.SetActive(true);
        _bloodyPovar.SetActive(false);
        music.enabled = false;
        yield return new WaitForSeconds(0.8f);
        _digitalGlitch.enabled = false;
        _analogGlitch.enabled = false;
        _backGround.SetActive(false);
        audio.enabled = false;
        horrormusic.enabled = true;
    }
}
