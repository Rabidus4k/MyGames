using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersController : MonoBehaviour
{
    [SerializeField]
    private GameObject _startDoor;
    [SerializeField]
    private GameObject _error;
    [SerializeField]
    private GameObject _errorCollider;

    [SerializeField]
    private GameObject _fallWalls;
    [SerializeField]
    private GameObject _fallBack;

    [SerializeField]
    private Movement _playerMovement;
    [SerializeField]
    private PlayerFire _playerFire;

    public static CollidersController inst;
    private void Start()
    {
        inst = this;
    }

    public static void TurnThePlayer(bool sostoyanie)
    {
        inst._playerMovement.enabled = sostoyanie;
        inst._playerFire.enabled = sostoyanie;
    }

    public static void ShowError()
    {
        Destroy(inst._errorCollider);
        inst._error.SetActive(true);
        inst._error.transform.localScale = Vector3.zero;
        LeanTween.scale(inst._error, Vector3.one, 0.1f);
    }

    public void OkPressed()
    {
        LeanTween.scale(inst._error, Vector3.zero, 0.1f);
        inst._error.SetActive(false);
    }

    public static void OpenStartDoor()
    {
        inst._startDoor.SetActive(false);
        inst._fallBack.SetActive(true);
        inst._fallWalls.SetActive(true);
    }
}
