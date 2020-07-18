using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSettings : MonoBehaviour
{
    public float _PlanetSize { get; private set; }
    public Vector3 _PlanetPosition { get; private set; }
    public GameObject _Objects;
    [SerializeField] private float _PlanetSpeed;

    private void Awake()
    {
        _PlanetSize = transform.localScale.x;
        _PlanetPosition = transform.position;
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, _PlanetSpeed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up * 1.2f * _PlanetSpeed * Time.fixedDeltaTime);
    }
}
