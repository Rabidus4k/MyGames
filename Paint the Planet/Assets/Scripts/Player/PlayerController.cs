using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _MoveSpeed = 5f;
    [SerializeField] private ErrorController _ErrorController;

    [SerializeField] private float _LookSpeed = 2f;
    private float _Rotation = 0f;

    public GameObject _ToolAxe;
    public GameObject _ToolPick;
    public GameObject _BluePrint;
    public GameObject _ToolHummer;

    private Animator _Animator;

    public ItemSlot _FirstItem;
    public ItemSlot _SecontItem;
    public ItemSlot _ThirdItem;
    public ItemSlot _FourthItem;

    public GameObject Items;

    public int currentSlotNumber = 1;

    private void Start()
    {
        _Animator = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        try
        {
            float mouseX = Input.GetAxis("Mouse X");
            _Rotation -= mouseX;
            _Rotation = Mathf.Clamp(_Rotation, -90f, 90f);
            transform.Rotate(new Vector3(0, mouseX * _LookSpeed, 0));


            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * _MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * _MoveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * _MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * _MoveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Alpha1))
            {
                PickSlotItem(_FirstItem._SlotItemName);
                currentSlotNumber = 1;
            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                PickSlotItem(_SecontItem._SlotItemName);
                currentSlotNumber = 2;
            }

            if (Input.GetKey(KeyCode.Alpha3))
            {
                PickSlotItem(_ThirdItem._SlotItemName);
                currentSlotNumber = 3;
            }

            if (Input.GetKey(KeyCode.Alpha4))
            {
                PickSlotItem(_FourthItem._SlotItemName);
                currentSlotNumber = 4;
            }

            if (Input.GetMouseButton(0))
            {
                _Animator.SetBool("IsHit", true);
            }
            else
            {
                _Animator.SetBool("IsHit", false);
            } 
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public void DeleteItemFromInventory()
    {
        Transform[] items = Items.GetComponentsInChildren<Transform>();
        for (int i = 1; i< items.Length; i++)
        {
            if (items[i].gameObject.tag == "Item" && items[i].gameObject.GetComponent<DranAndDrop>().slot.Number == currentSlotNumber)
            {
                items[i].gameObject.GetComponent<DranAndDrop>().Use();
            }
        }
    }

    public void PickSlotItem(string itemName)
    {
        switch (itemName)
        {
            case ("axe"):
                _ToolAxe.SetActive(true);

                _ToolPick.SetActive(false);
                _BluePrint.SetActive(false);
                _ToolHummer.SetActive(false);

                _Animator.SetInteger("Tool", 1);
                _Animator.Play("Tool_Axe_Idle");
                break;
            case ("pickaxe"):
                _ToolPick.SetActive(true);

                _ToolAxe.SetActive(false);
                _BluePrint.SetActive(false);
                _ToolHummer.SetActive(false);

                _Animator.SetInteger("Tool", 2);
                _Animator.Play("Tool_Pick_Idle");
                break;
            case ("hammer"):
                _ToolHummer.SetActive(true);

                _ToolPick.SetActive(false);
                _ToolAxe.SetActive(false);
                _BluePrint.SetActive(false);

                _Animator.SetInteger("Tool", 4);
                _Animator.Play("Tool_Hummer_Idle");
                break;
            case ("chest"):
                _BluePrint.SetActive(true);
                _BluePrint.GetComponent<Interaction>().ChooseBlueprint("chest");
                _ToolPick.SetActive(false);
                _ToolAxe.SetActive(false);
                _ToolHummer.SetActive(false);

                _Animator.SetInteger("Tool", 3);
                _Animator.Play("Tool_Blueprint_Idle");
                break;
            case ("workbench"):
                _BluePrint.SetActive(true);
                _BluePrint.GetComponent<Interaction>().ChooseBlueprint("workbench");
                _ToolPick.SetActive(false);
                _ToolAxe.SetActive(false);
                _ToolHummer.SetActive(false);

                _Animator.SetInteger("Tool", 3);
                _Animator.Play("Tool_Blueprint_Idle");
                break;
            case ("fence"):
                _BluePrint.SetActive(true);
                _BluePrint.GetComponent<Interaction>().ChooseBlueprint("fence");
                _ToolPick.SetActive(false);
                _ToolAxe.SetActive(false);
                _ToolHummer.SetActive(false);

                _Animator.SetInteger("Tool", 3);
                _Animator.Play("Tool_Blueprint_Idle");
                break;
            default:
                _BluePrint.SetActive(false);
                _ToolPick.SetActive(false);
                _ToolAxe.SetActive(false);
                _ToolHummer.SetActive(false);
                break;
        }
    }
}
