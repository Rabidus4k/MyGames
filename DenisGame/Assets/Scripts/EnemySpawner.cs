using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject _EnemyPref;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnerTimer");  
    }

    IEnumerator SpawnerTimer()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(_EnemyPref, transform.position, Quaternion.identity);
        StartCoroutine("SpawnerTimer");
    }
   
}
