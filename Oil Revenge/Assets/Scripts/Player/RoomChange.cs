using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public GameObject Camera;

    private GameObject[] Rooms;
    private int activeRoom;
    private Animator anim;
    private float playerX = 5f;
    private float playerY = 5f;
    private float cameraX = 19f;
    private float cameraY = 11f;


    float StartDelay = 5f;
    float Delay = 5f;
    void Start()
    {
        this.Delay = this.StartDelay;
        anim = GetComponent<Animator>();
        Rooms = GameObject.FindGameObjectsWithTag("Room");

        //for (int i = 0; i < Rooms.Length; i++)
        //{
        //    Rooms[i].SetActive(false);
        //}
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < Rooms.Length; i++)
        {
            //if (Camera.transform.position == Rooms[i].transform.position)
            //{
            //    Rooms[i].SetActive(true);
            //}
            //else
            //{
            //    Rooms[i].SetActive(false);
            //}
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Right_Door")
        {
            StartCoroutine(e1());  
        }

        if (collision.gameObject.tag == "Left_Door")
        {
            StartCoroutine(e2());
        }

        if (collision.gameObject.tag == "Up_Door")
        {
            StartCoroutine(e3());
        }

        if (collision.gameObject.tag == "Down_Door")
        {
            StartCoroutine(e4());
        }

       // StopAllCoroutines();
    }

    IEnumerator e1()
    {
        anim.SetBool("isPerehod", true);
        yield return new WaitForSeconds(.3f);
        transform.position = new Vector3(transform.position.x + playerX, transform.position.y, 0);
        Camera.transform.position = new Vector3(Camera.transform.position.x + cameraX, Camera.transform.position.y, 0);
    }

    IEnumerator e2()
    {
        anim.SetBool("isPerehod", true);
        yield return new WaitForSeconds(.3f);
        transform.position = new Vector3(transform.position.x - playerX, transform.position.y, 0);
        Camera.transform.position = new Vector3(Camera.transform.position.x - cameraX, Camera.transform.position.y, 0);
    }

    IEnumerator e3()
    {
        anim.SetBool("isPerehod", true);
        yield return new WaitForSeconds(.3f);
        transform.position = new Vector3(transform.position.x, transform.position.y + playerY, 0);
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y + cameraY, 0);
    }

    IEnumerator e4()
    {
        anim.SetBool("isPerehod", true);
        yield return new WaitForSeconds(.3f);
        transform.position = new Vector3(transform.position.x, transform.position.y - playerY, 0);
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - cameraY, 0);

    }

    public void setFalse()
    {
        anim.SetBool("isPerehod", false);
    }
}
