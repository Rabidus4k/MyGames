using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public string _SlotItemName;
    public int Number = 0;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            _SlotItemName = eventData.pointerDrag.GetComponent<DranAndDrop>()._Name;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 
            eventData.pointerDrag.GetComponent<DranAndDrop>().wasDroped = true;
            eventData.pointerDrag.GetComponent<DranAndDrop>().slot = this;
            eventData.pointerDrag.transform.parent = gameObject.transform.parent;
        }
    }
}
