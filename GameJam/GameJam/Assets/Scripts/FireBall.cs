using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FireBall : MonoBehaviour
{

    [SerializeField]
    private float _fireBallSpeed;
    [SerializeField]
    private GameObject _explosionPref;
    private Rigidbody2D _rigidbody2D;

    private Vector3 _moveToPosition;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(_fireBallSpeed * Time.deltaTime * Vector3.right );
        
    }

    public void SetMoveToPosition(Vector3 finishPosition)
    {
        _moveToPosition = finishPosition;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            return;
        DestroyFireBall();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {

            DestroyFireBall();
        }

        if (other.tag == "Girl")
        {
            DialogueController.DialogueShow("OH, NOOOOO!!", null);
            GameObject.FindGameObjectWithTag("4").GetComponent<RoomController>().DoSomothing1();
            Destroy(other.gameObject);
            DestroyFireBall();
            FinishController.Show();
        }
    }


    void DestroyFireBall()
    {
        Instantiate(_explosionPref, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
