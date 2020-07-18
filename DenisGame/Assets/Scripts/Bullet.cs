using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody Rigidbody;
    private float _BulletSpeed = 15f;
    private float LifeTime = 0.5f;
    // Update is called once per frame
    private void Start()
    {
        LifeTime = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().BulletLifeTime;
        _BulletSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().BulletSpeed;
        Rigidbody = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject, LifeTime);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _BulletSpeed * Time.deltaTime);
    }
}
