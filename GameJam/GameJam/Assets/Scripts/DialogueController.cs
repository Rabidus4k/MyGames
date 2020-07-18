using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueController : MonoBehaviour
{
    public AudioSource audio;
    [SerializeField]
    private TextMeshProUGUI _dialogueText;
    public static DialogueController inst;
    private int _currentChar;

    private float _textSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        _textSpeed = 0.05f;
        inst = this;
    }

    public static void DialogueShow(string text, MyDelegate method)
    {
        inst.StopAllCoroutines();
        inst._currentChar = 0;
        inst._dialogueText.SetText(string.Empty);
        inst.gameObject.SetActive(true);
        inst.StartCoroutine(inst.SlowTextAppear(text, method));
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _textSpeed = 0.01f;
        } 
        else 
        {
            _textSpeed = 0.05f;
        } 
    }

    private IEnumerator SlowTextAppear(string text, MyDelegate method)
    {
        yield return new WaitForSeconds(_textSpeed);

        if (_currentChar != text.Length)
        {
            CollidersController.TurnThePlayer(false); 
            if (text[_currentChar] == '@')
            {
                yield return new WaitForSeconds(_textSpeed * 40f);
                _dialogueText.text = string.Empty;
                _currentChar++;
                
            }

            if (text[_currentChar] == '#')
            {
                method.Invoke();
                _currentChar++;
            }
            if (text[_currentChar] == '$')
            {
                CollidersController.TurnThePlayer(true);
            }
            audio.Play();
            _dialogueText.text += text[_currentChar];
            _currentChar++;
            StartCoroutine(SlowTextAppear(text, method));
        }
        else
        {
            CollidersController.TurnThePlayer(true);
            yield return new WaitForSeconds(_textSpeed * 20f);
            _dialogueText.text = string.Empty;
            gameObject.SetActive(false);
        }
    }
}
