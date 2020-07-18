using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimizatoin : MonoBehaviour
{
    public List<GameObject> _Objects = new List<GameObject>();

    private void Start()
    {
        StartCoroutine("Wait");
    }

    public void StartOptimization()
    {
        _Objects.AddRange(GameObject.FindGameObjectsWithTag("Tree"));
        _Objects.AddRange(GameObject.FindGameObjectsWithTag("Stone"));
        _Objects.AddRange(GameObject.FindGameObjectsWithTag("FireCamp"));
        _Objects.AddRange(GameObject.FindGameObjectsWithTag("Chest"));
        _Objects.AddRange(GameObject.FindGameObjectsWithTag("Workbench"));
        _Objects.AddRange(GameObject.FindGameObjectsWithTag("Fence"));
       
        CheckForDistance();
        StartCoroutine("UpdateMap");
    }

    IEnumerator UpdateMap()
    {
        yield return new WaitForSeconds(.1f);
        CheckForDistance();
        StartCoroutine("UpdateMap");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        StartOptimization();    
    }


    private void CheckForDistance()
    {
        foreach (GameObject obj in _Objects)
        {
            if (obj != null)
            {
                if (Vector3.Distance(transform.position, obj.transform.position) > 30f)
                {
                    obj.SetActive(false);
                }
                else
                {
                    obj.SetActive(true);
                }
            } 
        }
    }
}
