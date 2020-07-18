using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    private float m_BirdSpeed = 5f;
    void Update()
    {
        transform.Translate(Vector3.right * m_BirdSpeed * Time.deltaTime);
    }
}
