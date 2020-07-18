using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public int RotationSpeed = 1;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45 * RotationSpeed) * Time.deltaTime);
    }
}
