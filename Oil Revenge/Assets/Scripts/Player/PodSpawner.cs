using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodSpawner : MonoBehaviour
{
    public GameObject pod;
    private int podsAround;

    private void Start()
    {

    }

    void Update()
    {
        podsAround = GameObject.FindGameObjectsWithTag("Pod").Length;

        if (podsAround < 4)
        {
            Vector3 pos = new Vector3(Random.Range(transform.position.x + 5, transform.position.x + 50), Random.Range(transform.position.y + 5, transform.position.y + 50), 0);

            Vector3 pos2 = new Vector3(Random.Range(transform.position.x + 5, transform.position.x + 50), Random.Range(transform.position.y - 50, transform.position.y - 5), 0);
            Vector3 pos3 = new Vector3(Random.Range(transform.position.x - 50, transform.position.x - 5), Random.Range(transform.position.y + 5, transform.position.y + 50), 0);
            Vector3 pos4 = new Vector3(Random.Range(transform.position.x - 50, transform.position.x - 5), Random.Range(transform.position.y - 50, transform.position.y - 5), 0);

            Instantiate(pod, pos, Quaternion.identity);   
            Instantiate(pod, pos2, Quaternion.identity);   
            Instantiate(pod, pos3, Quaternion.identity);   
            Instantiate(pod, pos4, Quaternion.identity);   
        }
    }
}
