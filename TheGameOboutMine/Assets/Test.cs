using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            Debug.Log("LALT");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("LCTRL");
        }
    }
}
