using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Back")
        {
            Enemy_Spawner.Respawn(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Enemy_Spawner.Respawn(gameObject);
            Enum.isDead = true;
        }
    }

    public Vector2 direction = new Vector2(1, 0);
    private void FixedUpdate()
    {
        transform.Translate(Enum.globalSpeed * direction * Time.deltaTime, Space.World);
    }


}
