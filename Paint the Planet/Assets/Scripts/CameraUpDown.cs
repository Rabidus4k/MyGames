using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpDown : MonoBehaviour
{
    private float Rotation = 0f;
    private Quaternion lastRotation;

    private void Start()
    {
        lastRotation = transform.localRotation;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            float mouseY = Input.GetAxis("Mouse Y");
            float mouseX = Input.GetAxis("Mouse X");

            Rotation -= mouseY;
            Rotation = Mathf.Clamp(Rotation, -90f, 20f);

            transform.localRotation = Quaternion.Euler(Rotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
        else
        {
            transform.localRotation = lastRotation;
            Rotation = 0f;
        }
    }
}
