using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public Transform _Container;
    public GameObject _ListItemPrefab;

    public void AddItem()
    {
        GameObject tempObj = Instantiate(_ListItemPrefab);
        tempObj.transform.parent = _Container;
    }
}

