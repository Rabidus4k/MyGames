using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovarMove : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _points;
    [SerializeField]
    private Animator _animator;

    public static PovarMove inst;
    private Vector3 _start;
    
    private void Start()
    {
        inst = this;
        _start = transform.position;
    }
    public static void StartMove()
    {
        inst._animator.Play("Povar_N_Walk");

        inst.TurnLeft();
        LeanTween.move(inst.gameObject, inst._points[Slot.Count].transform, 1f).setOnComplete(inst.GoBack);
    }

    public void GoBack()
    {
        _animator.Play("Povar_N_Idle");
        FoodController.SpawnFood();
        LeanTween.move(gameObject, _start, 1f).setDelay(1f).setOnStart(TurnRight);
       
    }

    public void TurnRight()
    {
        _animator.Play("Povar_N_Walk");
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void TurnLeft()
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }
}
