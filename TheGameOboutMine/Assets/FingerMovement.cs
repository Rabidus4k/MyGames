using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMovement : MonoBehaviour
{
    Vector3 Pos1, Pos2;
    float speed = 30f;
    void Start()
    {
        Pos1 = transform.position;
        Pos2 = new Vector2(transform.position.x, transform.position.y - 10);
    }

    void FixedUpdate()
    {  
        if (transform.position.y <= Pos1.y - 10)
        {
            StartCoroutine("Yield");
        }
        else
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
    }


    IEnumerator Yield()
    {
        yield return new WaitForSeconds(.15f);
        Destroy(gameObject);
    }
}