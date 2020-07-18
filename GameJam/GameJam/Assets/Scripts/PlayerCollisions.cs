using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public delegate void MyDelegate();
public class PlayerCollisions : MonoBehaviour
{
    public Transform start;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MonsterFireball"))
        {
            transform.position = start.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StartTrigger"))
        {
            MyDelegate method = new MyDelegate(CollidersController.OpenStartDoor);

            CollidersController.ShowError();
            DialogueController.DialogueShow(
                "Oh, honey, something wrong with me, wait a bit..." +
                "@I did something wrong. I don't know, but I'm out of control, hmm.." +
                "@#Oops, honey, please sorry, I didn't want to do it, find path to get here again!"
                + "@The door is locked!"
                + "@To go to the next floor, find the key near the blue flag", method);

        }

        if (collision.gameObject.CompareTag("Richag"))
        {
            collision.gameObject.GetComponent<Richag>().TurnRichag();
        }


        if (collision.gameObject.CompareTag("Door"))
        {
            collision.gameObject.GetComponent<DoorTransition>().Teleport();
        }

        if (collision.gameObject.CompareTag("3_1"))
        {
            Destroy(collision.gameObject);
            DialogueController.DialogueShow("Here you sould turn on the lever to lower the ladder.", null);
        }

        if (collision.gameObject.CompareTag("1_1"))
        {
            GameObject FBFlag = GameObject.Find("FakeBlueFlag");
            GameObject FRFlag = GameObject.Find("FakeRedFlag");

            FBFlag.SetActive(false);
            FRFlag.SetActive(false);


            
            Destroy(collision.gameObject);
            DialogueController.DialogueShow("I said near the BLUE flag!", null);
        }

        if (collision.gameObject.CompareTag("1_2"))
        {
            if (GameObject.Find("BlueFlag").active)
            {
                DoorTransition.canTeleport = true;
                Destroy(collision.gameObject);
                DialogueController.DialogueShow("Yes, honey, the door opened!", null);
            }

        }

        if (collision.gameObject.CompareTag("3_2"))
        {
            GameObject.FindGameObjectWithTag("Ladder").GetComponent<FalllDownItem>().Drop();
            MyDelegate method = new MyDelegate(GameObject.FindGameObjectWithTag("3").GetComponent<RoomController>().DoSomothing2);

            Destroy(collision.gameObject);
            DialogueController.DialogueShow(
                "Oops... Ok, I will try to help you" +
                "@Wait a second..." +
                "@#Now!" +
                " You should find another lever to fix the game!", method);
        }

        if (collision.gameObject.CompareTag("3_3"))
        {
            MyDelegate method = new MyDelegate(GameObject.FindGameObjectWithTag("3").GetComponent<RoomController>().DoSomothing1);
            Destroy(collision.gameObject);
            DialogueController.DialogueShow("Cool, #now....", method);
        }

        if (collision.gameObject.CompareTag("4_1"))
        {
            Destroy(collision.gameObject);
            DialogueController.DialogueShow(
                "@$You are finally back!!" +
                "@Why so long?.." +
                "@You should have been faster!" +
                "@Just don't touch me!", null);
        }
    }
}
