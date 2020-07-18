using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : MonoBehaviour
{
    private GameObject[] Players;
    private float distance;
    

    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < Players.Length; i++)
        {
            distance = Vector3.Distance(Players[0].transform.position, transform.position);
        }
       
        if (distance > 50f)
        {
            //Debug.Log(distance.ToString());
            removePod();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health.increaseHp(10);
            removePod();
        }
    }

    void removePod()
    {
        this.GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject, 2F);
        
    }
}
