using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] rooms;

    public void Start()
    {
        foreach (GameObject room in rooms)
        {
            room.SetActive(false);
        }

        rooms[0].SetActive(true);
    }
    public void Activate(int index)
    {
        rooms[index - 1].SetActive(true);

        for (int i = 0; i < rooms.Length; i++)
        {
            if (i == index - 1)
                continue;

            rooms[i].SetActive(false);
        }
    }
}
