using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string _Name = string.Empty;
    Transform _Player;

    private void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Teleport()
    {
        GameObject[] activePortals = GameObject.FindGameObjectsWithTag("Portal"); 

        foreach(GameObject portal in activePortals)
        {
            if (portal != this.gameObject)
            {
                if (portal.GetComponent<Portal>()._Name == this._Name)
                {
                    _Player.position = portal.transform.position + portal.transform.up;
                }
            }
        }
    }
}
