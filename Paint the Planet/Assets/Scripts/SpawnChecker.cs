using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChecker : MonoBehaviour
{
    public Material material;
    public static bool _CanPlaceBlock = true;

    private void OnEnable()
    {
        material.color = Color.green;
        _CanPlaceBlock = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tree" || other.gameObject.tag == "Stone" || other.gameObject.tag == "Chest" || other.gameObject.tag == "Workbench" || other.gameObject.tag == "Fence")
        {
            _CanPlaceBlock = false;
            material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tree" || other.gameObject.tag == "Stone" || other.gameObject.tag == "Chest" || other.gameObject.tag == "Workbench" || other.gameObject.tag == "Fence")
        {
            _CanPlaceBlock = true;
            material.color = Color.green;
        }   
    }
}
