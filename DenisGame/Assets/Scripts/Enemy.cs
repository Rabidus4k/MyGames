using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject HealthBar;
    public float HardLevel = 1f;
    public float SeeDistance = 15f;
    private float _Helath = 1f;
    private GameObject _Player;
    private float _EnemySpeed = 10.4f;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        _Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position,_Player.transform.position) < SeeDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _Player.transform.position, _EnemySpeed * Time.deltaTime);
            transform.LookAt(_Player.transform);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, _EnemySpeed * Time.deltaTime);
            transform.LookAt(startPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GetDamage(_Player.GetComponent<PlayerController>().Damage);
            if (UnityEngine.Random.Range(0, 100) > GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ShootChance)
                Destroy(other.gameObject);
        }
    }

    private void GetDamage(float damage)
    {
        _Helath -= damage / (100f * HardLevel);

        if (_Helath < 0)
        {
            _Player.GetComponent<Exp>().GetExp(10f * HardLevel);
            Destroy(gameObject);
        }
        else
        {
            HealthBar.transform.localScale = new Vector3(_Helath, 1f, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIController.GameOver();
        }
    }
}
