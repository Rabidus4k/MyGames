using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_BirdPrefab;
    void Start()
    {
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z);
        Instantiate(m_BirdPrefab, spawnPos, Quaternion.identity);
        StartCoroutine("Wait");
    }
}
