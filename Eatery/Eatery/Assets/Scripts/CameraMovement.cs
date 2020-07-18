using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, target.position, Time.deltaTime * 1f);
    }
}
