using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 1F;
    public float sneakSpeed = 1F;
    public float runSpeed = 1F;
    public GameObject mark;
    public GameObject Camera;

    //Bullet
    public Rigidbody2D bullet;
    public float bulletSpeed;
    private Vector3 spawnPos;
    private Vector3 lastPos;

    //Controll
    public FloatingJoystick Joystick;
    private CharacterController controller;
    private float speed;

    private Animator anim;

    public Text keyCountText; 
    private int keyCount;

    void Start() 
    {
        keyCount = 0;
        lastPos = Vector3.down;
        controller = GetComponent<CharacterController>();
        speed = walkSpeed;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        keyCountText.text = keyCount.ToString();

        anim.SetBool("goUp", false);
        anim.SetBool("goDown", false);
        anim.SetBool("goLeft", false);
        anim.SetBool("goRight", false);

        spawnPos = new Vector3(transform.position.x, transform.position.y - 0.3f, 0);

        if (Input.GetButton("Horizontal") || Joystick.Horizontal != 0)
        {        

            float moveSpeed = (Joystick.Horizontal ) * speed * Time.fixedDeltaTime;
            if (Joystick.Horizontal >= 0.2f)
            {
                lastPos = Vector3.right;
                anim.SetBool("goLeft", false);
                anim.SetBool("goRight", true);
            } else if (Joystick.Horizontal <= -0.2f)
            {
                lastPos = Vector3.left;
                anim.SetBool("goLeft", true);
                anim.SetBool("goRight", false);
            }
            transform.Translate(moveSpeed, 0, 0);
        }

        if (Input.GetButton("Vertical") || Joystick.Vertical != 0)
        {
            float moveSpeed = (Joystick.Vertical ) * speed * Time.fixedDeltaTime;
            if (Joystick.Vertical >= 0.2f)
            {
                lastPos = Vector3.up;
                anim.SetBool("goDown", false);
                anim.SetBool("goUp", true);
            }
            else if (Joystick.Vertical <= -0.2f)
            {
                lastPos = Vector3.down;
                anim.SetBool("goDown", true);
                anim.SetBool("goUp", false);
            }
            transform.Translate(0, moveSpeed, 0);
        }

    }

    public void Shoot()
    {
        Rigidbody2D clone = Instantiate(bullet, spawnPos, Quaternion.identity) as Rigidbody2D;
        clone.AddForce(lastPos * bulletSpeed, ForceMode2D.Impulse);
    }


    public void Mark()
    {
        Instantiate(mark, Camera.transform.position, Quaternion.identity);
        Health.getDamage(.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            keyCount++;
        }
    }
}
