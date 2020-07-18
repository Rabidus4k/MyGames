using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public GameObject _LootInv;
    private Transform _Slots;

    private void Start()
    {
        _Slots = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>()._Inventory.transform.GetChild(1);
    }


    public void TakeLoot()
    {
        ItemSlot[] itemsinslots = _Slots.GetComponentsInChildren<ItemSlot>();

        foreach(ItemSlot item in itemsinslots)
        {
            if (item._SlotItemName == string.Empty)
            {
                GameObject newObject = Instantiate(_LootInv);
                newObject.transform.parent = _Slots;
                newObject.transform.localScale = Vector3.one;
                newObject.transform.position = item.transform.position;
                item._SlotItemName = newObject.GetComponent<DranAndDrop>()._Name;
                newObject.GetComponent<DranAndDrop>().slot = item;
                Debug.Log("Took loot");
                Destroy(gameObject);

                return;
            }
        }

        Debug.Log("no places");
    }
}
