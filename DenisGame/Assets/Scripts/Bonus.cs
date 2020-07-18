using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float size;
    private float _Helath;
    public GameObject HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        _Helath = 1f;
        size = Random.Range(1.0f, 2.0f);
        transform.localScale = new Vector3(size,size,size);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GetDamage(0.1f / size);

            if (Random.Range(0,100) > GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ShootChance)
                Destroy(other.gameObject);
        }
    }

    private void GetDamage(float damage)
    {
        _Helath -= damage;

        if (_Helath < 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Exp>().GetExp(20f * size);
            Destroy(gameObject);
        }
        else
        {
            HealthBar.transform.localScale = new Vector3(_Helath, 1f, 1f);
        }
    }
}
