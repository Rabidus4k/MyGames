using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float _Gravity;
    [SerializeField] private GameObject _Player;

    public Transform _PlanetTransform;
    private Rigidbody _PlayerRigidbody;

    /// <summary>
    /// Вызывается один раз до первого обновления кадра
    /// </summary>
    private void Start()
    {
        _PlayerRigidbody = _Player.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Вызывается каждый кадр
    /// Высчитывает направление и силу, с которой данный объект притягивается к _PlanetTransform
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 gravityDirection = (_PlanetTransform.position - _Player.transform.position).normalized;
        _PlayerRigidbody.AddForce(gravityDirection * _Gravity);
        Quaternion playerRotation = Quaternion.FromToRotation(_Player.transform.transform.up, (-gravityDirection)) * _Player.transform.rotation;
        _Player.transform.rotation = Quaternion.Slerp(_Player.transform.rotation, playerRotation, 50 * Time.deltaTime);
    }
}
