using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritesController : MonoBehaviour
{
    Transform[] _Meteors;

    private void Start()
    {
        _Meteors = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }
}
