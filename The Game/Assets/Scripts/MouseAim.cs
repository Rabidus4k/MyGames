using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public float offset;
    public GameObject player;
    public Rigidbody2D bullet;
    public GameObject gun;


    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ;


        if (Input.GetKey(KeyCode.D))
        {
            rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rotateZ = 180 + Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        } else if (player.transform.localScale.x == -10)
        {
            rotateZ = 180 + Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        } else
        {
            rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody2D clone = Instantiate(bullet, gun.transform.position, gun.transform.rotation) as Rigidbody2D;
            //bullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(1,1), ForceMode2D.Impulse);
            clone.AddForce(difference * 10, ForceMode2D.Impulse);

        }
    }
    
}
