using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBall : MonoBehaviour
{

    [SerializeField]
    private float _monsterBallSpeed;

    void FixedUpdate()
    {
        transform.Translate(_monsterBallSpeed * Time.deltaTime * Vector3.right);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
