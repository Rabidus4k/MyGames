using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Richag : MonoBehaviour
{
    private Animator _animator;
    public AudioSource audio;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TurnRichag()
    {
        audio.Play();
        _animator.Play("Richag_Change");
    }
}
