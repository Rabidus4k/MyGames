using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float xOffset;
    public float yOffset;

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, target.position + new Vector3(xOffset, yOffset, 0), Time.deltaTime * 1f);
    }
}
