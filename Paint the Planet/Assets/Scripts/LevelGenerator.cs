using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _Prefs;
    [SerializeField] private ErrorController _ErrorController;
    [SerializeField] private TextMeshProUGUI _LogText;

    private PlanetSettings _CurPlanetSettings;

    private void Start()
    {
        _CurPlanetSettings = gameObject.GetComponent<PlanetSettings>();

        int ammoutToSpawn = (int)(200 * Mathf.Pow(_CurPlanetSettings._PlanetSize, 2f));
        for (int i = 0; i < ammoutToSpawn; i++)
        {
            SpawnPref();
        }
    }

    private void SpawnPref()
    {
        try
        {
            int rand = UnityEngine.Random.Range(0, _Prefs.Length);

            GameObject temp = Instantiate(_Prefs[rand], _CurPlanetSettings._PlanetPosition, Quaternion.identity);
            temp.transform.parent = gameObject.transform.GetComponent<PlanetSettings>()._Objects.transform;
            temp.transform.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360)));
            temp.transform.position = _CurPlanetSettings._PlanetPosition + temp.transform.up * (_CurPlanetSettings._PlanetSize * 31 + .5f);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
       
    }
}
