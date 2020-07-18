using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walls" ||
            collision.gameObject.tag == "Enemy" ||
            collision.gameObject.tag == "Left_Door" ||
            collision.gameObject.tag == "Right_Door" ||
            collision.gameObject.tag == "Up_Door" ||
            collision.gameObject.tag == "Down_Door" ||
            collision.gameObject.tag == "Chest")
        {
            Destroy(this.gameObject);
        }
    }

}
