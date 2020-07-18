using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public float hp = 1;

    private void Update()
    {
        if (hp <= 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
