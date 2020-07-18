using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float _Gravity = 9.8f;
    [SerializeField] private GameObject _Player;

    public string _PlanetTag = "Planet_3";

    public Transform _PlanetTransform;
    private Rigidbody _PlayerRigidBody;

    void Start()
    {
        _PlanetTransform = GameObject.FindGameObjectWithTag(_PlanetTag).GetComponent<Transform>();
        _PlayerRigidBody = _Player.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        try
        {
            Vector3 gravityDirection = (_PlanetTransform.position - transform.position).normalized;
            _PlayerRigidBody.AddForce(gravityDirection * _Gravity);
            Quaternion playerRotation = Quaternion.FromToRotation(transform.up,(-gravityDirection)) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, 50 * Time.deltaTime);

            
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Planet"))
        {
            _PlanetTag = other.tag;
            transform.parent = GameObject.FindGameObjectWithTag(_PlanetTag).GetComponent<PlanetSettings>()._Objects.transform;
            _PlanetTransform = GameObject.FindGameObjectWithTag(_PlanetTag).GetComponent<Transform>();
            _PlayerRigidBody.mass = 1f;
            _Gravity = 9.8f;
        }
    }
}
