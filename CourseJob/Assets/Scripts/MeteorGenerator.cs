using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MeteorGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _MeteorPref;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRate(.6f));
    }

    /// <summary>
    /// Рекурсивная функция
    /// </summary>
    /// <param name="time">Время, через которая данная функция вызывает саму себя</param>
    /// <returns></returns>
    public IEnumerator SpawnRate(float time)
    {
        SpawnMeteor();
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnRate(.6f));
    }

    /// <summary>
    /// Располагает ново-созданный объект на карте
    /// </summary>
    public void SpawnMeteor()
    {   
        GameObject newMeteor = Instantiate(_MeteorPref, Vector3.zero, Quaternion.identity);

        newMeteor.transform.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360)));
        newMeteor.transform.position = Vector3.zero + newMeteor.transform.up * -100;
    }


}
