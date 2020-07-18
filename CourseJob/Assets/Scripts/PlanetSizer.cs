using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSizer : MonoBehaviour
{
    public GameObject _Planet;
    public float _Size = 1;

    // Update is called once per frame
    // Уменьшает размер планеты
    void FixedUpdate()
    {
        _Planet.transform.localScale = new Vector3(_Size, _Size, _Size);
        if (_Size > 0.4)  
            _Size -= 0.0002f;
        else if (_Size > 0.2)
            _Size -= 0.00005f;
    }
}
