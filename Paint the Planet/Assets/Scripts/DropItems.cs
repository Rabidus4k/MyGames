using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public void DropAllItems(GameObject itemCollector)
    {
        
        Transform[] items = itemCollector.GetComponentsInChildren<Transform>();
        foreach(Transform item in items)
        {
            if (item.gameObject.CompareTag("Item"))
            {
                GameObject newObject = Instantiate(item.gameObject.GetComponent<DranAndDrop>()._ItemPref, transform.position, transform.rotation);
                newObject.transform.parent = GameObject.FindGameObjectWithTag(GameObject.FindGameObjectWithTag("Player").GetComponent<Gravity>()._PlanetTag).GetComponent<PlanetSettings>()._Objects.transform;
            }
        }
    }
}
