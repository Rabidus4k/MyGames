    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotation : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(1, 1, 0) * Time.fixedDeltaTime * 0.05f);
    }
}
