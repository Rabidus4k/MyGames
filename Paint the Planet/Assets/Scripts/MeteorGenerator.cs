using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGenerator : MonoBehaviour
{
    private GameObject _Player;

    public GameObject _MeteorPrefab;
    private string _PlanetTagToSpawn = string.Empty;

    private void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SpawnMeteor()
    {
        _PlanetTagToSpawn = _Player.GetComponent<Gravity>()._PlanetTag;
        PlanetSettings PlanetToSpawnSettings = GameObject.FindGameObjectWithTag(_PlanetTagToSpawn).GetComponent<PlanetSettings>();

        GameObject newMeteor = Instantiate(_MeteorPrefab, PlanetToSpawnSettings._PlanetPosition, Quaternion.identity);

        newMeteor.transform.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360)));
        newMeteor.transform.position = PlanetToSpawnSettings._PlanetPosition + newMeteor.transform.up * (PlanetToSpawnSettings._PlanetSize * 200);
    }

}
