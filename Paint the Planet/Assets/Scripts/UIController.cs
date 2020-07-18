using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private CameraController _CameraController;

    public GameObject _Inventory;
    public GameObject _PostProcessing;
    public GameObject _UI_StartButton;

    public GameObject _Minimap;
    public GameObject _Hugemap;

    private GameObject _Player;
    [SerializeField] Interaction Interaction;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Locked;
        _CameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            if (_Inventory.active)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (_Hugemap.active)
            {
                _Hugemap.SetActive(false);
                _Minimap.SetActive(true);
            }
            else
            {
                _Hugemap.SetActive(true);
                _Minimap.SetActive(false);
            }
        }
    }

    public void OpenInventory()
    {
        _Inventory.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Interaction.enabled = false;
    }

    public void CloseInventory()
    {
        _Inventory.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Interaction.enabled = true;
    }

    public void Clicked_OnStart()
    {
        _CameraController.enabled = true;
        _UI_StartButton.SetActive(false); 
    }

    public void Clicked_PostProcessingOFF()
    {
        _PostProcessing.SetActive(!_PostProcessing.active);
    }

    public void Clicked_Quit()
    {
        Application.Quit(0);
    }

    public void SpeedUp(float speed)
    {
        Time.timeScale = speed;
    }

}
