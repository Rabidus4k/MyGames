using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10f;
    public float Damage = 10f;
    public float BulletSpeed = 15f;
    public float ShootChance = 0f;
    public float ReloadSpeed = 1f;
    public float BulletLifeTime = 0.5f;

    private int GunChoose = 0;

    public GameObject BulletPref;

    public GameObject ReloadBar;
    public GameObject ChooseGun;
    public Camera cam;
    public GameObject Model;
    public GameObject[] Guns;
    public Rotation gunRotation;
    private float curreload = 1f;

    private void Update()
    {
        curreload += ReloadSpeed / 100000f;

        if (curreload > 1)
            curreload = 1;

        if (curreload < 0)
            curreload = 0;

        ReloadBar.transform.localScale = new Vector3(curreload, 1, 1);

        switch(GunChoose)
        {
            case 0:
                if (Input.GetMouseButtonDown(0) && curreload > 0.1f)
                {
                    Instantiate(BulletPref, Guns[0].transform.position, Guns[0].transform.rotation);
                    curreload -= 0.1f;
                }
                break;
            case 1:
                if (Input.GetMouseButton(0) && curreload > 0.1f)
                {
                    Instantiate(BulletPref, Guns[0].transform.position, Guns[0].transform.rotation);
                    curreload -= 0.05f;
                    gunRotation.RotationSpeed = 10;
                }
                else
                {
                    gunRotation.RotationSpeed = 1;
                }
                break;
            case 2:
                if (Input.GetMouseButtonDown(0) && curreload >= 0.5f)
                {
                    Instantiate(BulletPref, Guns[0].transform.position, Guns[0].transform.rotation);
                    curreload -= 0.5f;
                }
                break;
            default:
                break;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            if (!hit.collider.gameObject.CompareTag("Bullet"))
            {
                Vector3 rot = transform.eulerAngles;
                Model.transform.LookAt(hit.point);
                Model.transform.eulerAngles = new Vector3(rot.x, Model.transform.eulerAngles.y, rot.z);
            }

        }  
    }

    public void SwitchGun(int num)
    {
        ChooseGun.SetActive(false);
        switch (num)
        {
            case 0:
                Speed *= 1.2f;
                ReloadSpeed = 100f;
                ShootChance *= 0.7f;
                break;
            case 1:
                Damage *= 0.8f;
                ShootChance += 20;
                Speed *= 0.8f;
                break;
            case 2:
                BulletSpeed *= 2;
                Damage *= 2;
                Speed *= 0.6f;
                break;
            case 3:
                GameObject.FindGameObjectWithTag("Player").GetComponent<Exp>().GetPoints(5);
                SwitchGun(Random.Range(0,2));
                return;
            default:
                break;
        }


        Guns[GunChoose].SetActive(false);
        GunChoose = num;
        Guns[GunChoose].SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            UIController.GameOver();
        }
    }
    
}