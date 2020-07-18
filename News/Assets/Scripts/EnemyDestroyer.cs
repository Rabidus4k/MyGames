using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            gameObject.SetActive(false);
        }
    }
}
