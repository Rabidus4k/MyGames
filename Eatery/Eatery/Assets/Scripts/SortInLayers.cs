using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortInLayers : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 5000;
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool runOnlyOnce = false;

    private Renderer renderer;

    private void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        renderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);

        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
