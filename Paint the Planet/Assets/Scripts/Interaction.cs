using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Animator _PlayerAnimator;

    public AudioSource _HitSound;
    public ParticleSystem _ParticleSystem;

    public GameObject _ChestPrefModel;
    public GameObject _ChestPref;
    public GameObject _FencePrefModel;
    public GameObject _FencePref;
    public GameObject _WorkbenchPrefModel;
    public GameObject _WorkbenchPref;
    private string Name;
    public Transform _SpawnPoint;
    private void Start()
    {
        _PlayerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void Update()
    {
        if (SpawnChecker._CanPlaceBlock && Input.GetMouseButtonDown(0) && _PlayerAnimator.GetInteger("Tool") == 3)
        {
            GameObject newObject = null;

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().DeleteItemFromInventory();

            switch (Name) 
            {
                case ("chest"):
                    newObject = Instantiate(_ChestPref, _SpawnPoint.position, _SpawnPoint.rotation);
                    break;
                case ("workbench"):
                    newObject = Instantiate(_WorkbenchPref, _SpawnPoint.position, _SpawnPoint.rotation);
                    break;
                case ("fence"):
                    newObject = Instantiate(_FencePref, _SpawnPoint.position, _SpawnPoint.rotation);
                    break;
            }

            newObject.transform.parent = GameObject.FindGameObjectWithTag(GameObject.FindGameObjectWithTag("Player").GetComponent<Gravity>()._PlanetTag).GetComponent<PlanetSettings>()._Objects.transform;
            //_HitSound.Play();
            newObject.transform.localScale = Vector3.one / GameObject.FindGameObjectWithTag(GameObject.FindGameObjectWithTag("Player").GetComponent<Gravity>()._PlanetTag).GetComponent<PlanetSettings>()._PlanetSize;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Optimizatoin>()._Objects.Add(newObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Tree") && _PlayerAnimator.GetInteger("Tool") == 1 && _PlayerAnimator.GetBool("IsHit"))
        {
            if (other.gameObject != null)
                other.GetComponent<Destroyable>().GetDamage(Random.Range(1, 2));
            //_HitSound.Play();
            //_ParticleSystem.Play();
        }

        if (other.CompareTag("Stone") && _PlayerAnimator.GetInteger("Tool") == 2 && _PlayerAnimator.GetBool("IsHit"))
        {
            if (other.gameObject != null)
                other.GetComponent<Destroyable>().GetDamage(Random.Range(1, 2));
            //_HitSound.Play();
            //_ParticleSystem.Play();
        }

        if ((other.CompareTag("Chest") || other.CompareTag("Workbench") || other.CompareTag("Fence")) && _PlayerAnimator.GetInteger("Tool") == 4 && _PlayerAnimator.GetBool("IsHit"))
        {
            if (other.gameObject != null)
                other.GetComponent<Destroyable>().GetDamage(1);
            //_HitSound.Play();
            //_ParticleSystem.Play();
        }
    }
    
    public void ChooseBlueprint(string name)
    {
        Name = name;
        switch (name)
        {
            case ("chest"):
                _ChestPrefModel.SetActive(true);
                _FencePrefModel.SetActive(false);
                _WorkbenchPrefModel.SetActive(false);
                break;
            case ("workbench"):
                _ChestPrefModel.SetActive(false);
                _FencePrefModel.SetActive(false);
                _WorkbenchPrefModel.SetActive(true);
                break;
            case ("fence"):
                _ChestPrefModel.SetActive(false);
                _FencePrefModel.SetActive(true);
                _WorkbenchPrefModel.SetActive(false);
                break;
        }
    }
}
