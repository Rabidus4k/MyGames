using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject ChestIU;
    public GameObject GUI;
    
    public GameObject NewChest()
    {
        GameObject newChestUI = Instantiate(ChestIU, GUI.transform);
        return newChestUI;
    }
}
