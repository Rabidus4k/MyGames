using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject cube;

    private int maxCount = 100;
    private int countOfCubes = 0;
    // Update is called once per frame
    static Map inst;
    GameObject Camera;
    private void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        inst = this;
    }

    void FixedUpdate()
    {
        while(countOfCubes <= maxCount)
        {
            Instantiate(cube, new Vector3(Camera.transform.position.x + Random.Range(-20 ,40), Camera.transform.position.y + Random.Range(-20, 40), Camera.transform.position.z + Random.Range(-5, 40)), Quaternion.identity);
            countOfCubes++;
        }   
    }
    
    public static void D()
    {
        inst.DestroyObject();
    }
    public void DestroyObject()
    {
        countOfCubes--;
    }
}
