using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField] private GameObject[] _MeteorLoot;
    [SerializeField] private GameObject _Model;
    [SerializeField] private ParticleSystem _Explosion;
    [SerializeField] private Transform _SpawnPoint;
    private float _MeteorSpeed = 90f;
    public AudioSource _ExplosionSound;
    private Gravity gravity;

    private void Start()
    {
        gravity = GameObject.FindGameObjectWithTag("Player").GetComponent<Gravity>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * _MeteorSpeed * Time.deltaTime);   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(gravity._PlanetTag))
        {
            GameObject newLoot = Instantiate(_MeteorLoot[Random.Range(0,_MeteorLoot.Length)], _SpawnPoint.position, transform.rotation);
            newLoot.transform.parent = GameObject.FindGameObjectWithTag(gravity._PlanetTag).GetComponent<PlanetSettings>()._Objects.transform;
            
            _MeteorSpeed = 0f;
            _Model.SetActive(false);
            _Explosion.Play();
            _ExplosionSound.Play();
            Destroy(gameObject,5f);
        }
    }
}
