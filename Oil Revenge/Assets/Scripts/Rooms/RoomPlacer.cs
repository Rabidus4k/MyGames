using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomPlacer : MonoBehaviour
{
    public Room[] Rooms;
    public Room StartRoom;
    public Room BoosRoom;

    public int Num = 11;
    public int Chaos = 10;
    private Room[,] placeRooms;
    private int[,] vacant;
    private void Start()
    {
        vacant = new int[Num, Num];
        placeRooms = new Room[Num, Num];


        placeRooms[(Num - 1) /2, (Num - 1) / 2] = StartRoom;
        
        while(VountRooms() < Num)
        {
            FindV();
            PlaceR();
        }

        for (int i = 0; i < placeRooms.GetLength(0); i++)
        {
            for (int j = 0; j < placeRooms.GetLength(1); j++)
            {
                if (i + 1 < Num)
                {
                    if (placeRooms[i + 1, j] != null && placeRooms[i, j] != null)
                    {
                        //placeRooms[i, j].DoorRight.SetActive(true);
                        placeRooms[i + 1, j].DoorLeft.gameObject.SetActive(true);
                    }
                }
                if (i - 1 >= 0)
                {
                    if (placeRooms[i - 1, j] != null && placeRooms[i, j] != null)
                    {
                        //placeRooms[i, j].DoorLeft.SetActive(true);
                        placeRooms[i - 1, j].DoorRight.gameObject.SetActive(true);
                    }
                }
                if (j + 1 < Num)
                {
                    if (placeRooms[i, j + 1] != null && placeRooms[i, j] != null)
                    {
                        // placeRooms[i, j].DoorUp.SetActive(true);
                        placeRooms[i, j + 1].DoorDown.gameObject.SetActive(true);
                    }
                }
                if (j - 1 >= 0)
                {
                    if (placeRooms[i, j - 1] != null && placeRooms[i, j] != null)
                    {
                        // placeRooms[i, j].DoorDown.SetActive(true);
                        placeRooms[i, j - 1].DoorUp.gameObject.SetActive(true);
                    }
                }
            }
        }

    }



    void PlaceR()
    {
        for (int i = 0; i < vacant.GetLength(0); i++)
        {
            for (int j = 0; j < vacant.GetLength(1); j++)
            {
                if (vacant[i, j] == 2)
                {
                    int temp = Random.Range(0, Chaos);
                    if (temp == 0)
                    {
                        Room tempRoom = Instantiate(Rooms[Random.Range(0, Rooms.Length)], new Vector3((i - (Num - 1) / 2) * 19f, (j - (Num - 1) / 2) * 11f), Quaternion.identity);
                        placeRooms[i, j] = tempRoom;
                        vacant[i, j] = 1;
                    } else
                    {
                        placeRooms[i, j] = null;
                    }
                }
            }
        }
    }

  

    void FindV()
    {
        for (int i = 0; i < placeRooms.GetLength(0); i++)
        {
            for (int j = 0; j < placeRooms.GetLength(1); j++)
            {
                if (placeRooms[i,j] != null)
                {
                    vacant[i, j] = 1;
                    if (i + 1 < Num)
                    {
                        if (vacant[i + 1, j] != 1) vacant[i + 1, j] = 2;
                    }
                    if (i - 1 >= 0)
                    {
                        if (vacant[i - 1, j] != 1) vacant[i - 1, j] = 2;
                    }
                    if (j + 1 < Num)
                    {
                        if (vacant[i, j + 1] != 1) vacant[i, j + 1] = 2;
                    }
                    if (j - 1 >= 0)
                    {
                        if (vacant[i, j - 1] != 1) vacant[i, j - 1] = 2;
                    }
                }
            }
        }
    }

    int VountRooms()
    {
        int count = 0;
        for (int i = 0; i < placeRooms.GetLength(0); i++)
        {
            for (int j = 0; j < placeRooms.GetLength(1); j++)
            {
                if (placeRooms[i,j] != null) { count++; }
            }
        }

        return count;
    }

}