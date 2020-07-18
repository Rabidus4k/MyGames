using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
    public GameObject bonusPref;
    public int MaxCount = 20;
    public int CurrentCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < MaxCount; i++)
        {
            CurrentCount++;
            var newPosition = new Vector3(Random.Range(-250, 250), 0, Random.Range(-250, 250));
            Instantiate(bonusPref, newPosition, Quaternion.identity);
        }
        StartCoroutine("SpawnerTimer");
    }

    IEnumerator SpawnerTimer()
    {
        yield return new WaitForSeconds(1f);

        if (CurrentCount < MaxCount)
        {
            CurrentCount++;
            var newPosition = new Vector3(Random.Range(-250, 250), 0, Random.Range(-250, 250));
            Instantiate(bonusPref, newPosition, Quaternion.identity);
        }
        StartCoroutine("SpawnerTimer");
    }
}
