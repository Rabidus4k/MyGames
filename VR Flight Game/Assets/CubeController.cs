using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) > 40f)
        {
            Destroy(this.gameObject);
            Debug.Log("BOM");
            Map.D();
        }
    }
}
