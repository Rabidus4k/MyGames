using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollider : MonoBehaviour
{
    public GameObject _InteractText;
    public GameObject _Player;
    private bool canUsePortal = true;
    private bool canUseChest = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == null)
            return;

        if (other.gameObject.tag == ("Log"))
        {
            _InteractText.GetComponent<TextMeshProUGUI>().SetText("PRESS E TO TAKE");
            _InteractText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<XPController>().GetXP(5);
                Destroy(other.gameObject);
                _InteractText.SetActive(false);
            }
        }

        if (other.gameObject.tag == ("Chest"))
        {
            _InteractText.GetComponent<TextMeshProUGUI>().SetText("PRESS E");
            _InteractText.SetActive(true);

            if (canUseChest && Input.GetKey(KeyCode.E))
            {
                other.gameObject.GetComponent<Chest>().OpenChest();
                canUseChest = false;
            }
        }

        if (other.gameObject.tag == ("Workbench"))
        {
            _InteractText.GetComponent<TextMeshProUGUI>().SetText("PRESS E");
            _InteractText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                //Destroy(other.gameObject);
                //_InteractText.SetActive(false);
            }
        }

        if (other.gameObject.tag == ("Fence"))
        {
            _InteractText.GetComponent<TextMeshProUGUI>().SetText("PRESS E");
            _InteractText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                //Destroy(other.gameObject);
                //_InteractText.SetActive(false);
            }
        }

        if (other.gameObject.tag == ("Portal"))
        {
            _InteractText.GetComponent<TextMeshProUGUI>().SetText("PRESS E USE PORTAL");
            _InteractText.SetActive(true);

            if (canUsePortal && Input.GetKey(KeyCode.E))
            {
                canUsePortal = false;
                StartCoroutine("WaitForPortalToCoolDown");
                _InteractText.SetActive(false);
                other.gameObject.GetComponent<Portal>().Teleport();
            } 
            else if (!canUsePortal)
            {
                _InteractText.GetComponent<TextMeshProUGUI>().SetText("PORTAL IS ON COOLDOWN");
            }
        }

        if (other.gameObject.tag == ("Loot"))
        {
            _InteractText.GetComponent<TextMeshProUGUI>().SetText("PRESS E TO TAKE LOOT");
            _InteractText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<Loot>().TakeLoot();
            }
        }
    }

    IEnumerator WaitForPortalToCoolDown()
    {
        yield return new WaitForSeconds(2f);
        canUsePortal = true;
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == ("Log") || other.gameObject.tag == ("Portal") || other.gameObject.tag == ("Workbench") || other.gameObject.tag == ("Fence") || other.gameObject.tag == ("Loot"))
        {
            _InteractText.SetActive(false);
        }

        if (other.gameObject.tag == ("Chest"))
        {
            canUseChest = true;
            _InteractText.SetActive(false);
            other.gameObject.GetComponent<Chest>().CloseChest();
        }
    }
}
