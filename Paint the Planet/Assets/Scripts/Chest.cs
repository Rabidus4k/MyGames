using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest: MonoBehaviour
{
    public static int Index = 0;
    public int _Index;
    private bool _IsOpened = false;
    private ChestController chestController;
    private GameObject ChestUI;
    public void Start()
    {
        chestController = GameObject.FindGameObjectWithTag("ChestController").GetComponent<ChestController>();
        ChestUI = chestController.NewChest();
        _Index = Index;
        Index++;
    }

    public void CloseChest()
    {
        if (_IsOpened)
        {
            _IsOpened = false;
            Debug.Log("Close id:" + _Index);
            ChestUI.SetActive(false);
            GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().CloseInventory();
        }          
    }

    public void OpenChest()
    {
        if (!_IsOpened)
        {
            _IsOpened = true;
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Open id:" + _Index);
            ChestUI.SetActive(true);
            GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().OpenInventory();
        }
    }

    public void Delete()
    {
        GetComponent<DropItems>().DropAllItems(ChestUI);
        Destroy(ChestUI);
    }
}
