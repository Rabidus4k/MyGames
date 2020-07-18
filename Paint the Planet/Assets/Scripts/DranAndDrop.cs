using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DranAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector2 lastPosition;
    private string lastName;
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    public GameObject _ItemPref;
    public bool wasDroped = false;
    public ItemSlot slot;
    public string _Name = null;

    private void Awake()
    {
        lastPosition = Vector2.zero;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        lastName = slot._SlotItemName;

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentSlotNumber == slot.Number) 
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PickSlotItem("");
        }
        slot._SlotItemName = string.Empty;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!wasDroped)
        {
            ResetPosition();
            slot._SlotItemName = lastName;
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentSlotNumber == slot.Number)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PickSlotItem(lastName);
        }

        wasDroped = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        lastPosition = rectTransform.anchoredPosition;
    }

    public void ResetPosition()
    {
        rectTransform.anchoredPosition = lastPosition;
    }

    public void Use()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentSlotNumber == slot.Number)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PickSlotItem("");
        }
        slot._SlotItemName = string.Empty;
        Destroy(gameObject);
    }
}
