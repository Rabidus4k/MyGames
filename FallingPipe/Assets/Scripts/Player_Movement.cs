using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    private int direction = 0;
    private Animator anim;

    public void FixedUpdate()
    {
        anim = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.A) || (direction == -1))
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed, Space.World);
            anim.Play("goLeft");
        } else if (Input.GetKey(KeyCode.D) || (direction == 1))
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed, Space.World);

            anim.Play("goRight");
        }
        else
        {
            anim.Play("run");
        }



        if (Enum.isDead)
        {
            direction = 0;
        }

        //anim.Play("run");
    }

    public void goLeft()
    {
        direction = -1;
    }
    public void goRight()
    {

        direction = 1;
    }

    public void goStray()
    {
        direction = 0;
    }
}
