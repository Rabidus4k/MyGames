using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private int _Health;
    [SerializeField] private GameObject _LootPrefab;

    public void GetDamage(int damage)
    {
        Debug.Log("get damage");
        _Health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        
        if (_Health <= 0)
        {

            GameObject newLoot = Instantiate(_LootPrefab, transform.position, transform.rotation);
            newLoot.transform.parent = GameObject.FindGameObjectWithTag(GameObject.FindGameObjectWithTag("Player").GetComponent<Gravity>()._PlanetTag).GetComponent<PlanetSettings>()._Objects.transform;

            if (gameObject.tag == "Chest")
                GetComponent<Chest>().Delete();

            Destroy(gameObject);
        }
    }
}
