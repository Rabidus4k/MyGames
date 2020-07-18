using Photon.Pun;
using System;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathBuilder : MonoBehaviour
{   
    [SerializeField] private GameObject[] nextPointPrefabLeft;
    [SerializeField] private GameObject nextPointPrefabExit;
    [SerializeField] private GameObject nextPointPrefabDefault;
    private GameObject m_cart; 
    [SerializeField] private Transform cartIcon;
    [SerializeField] private GameObject m_exitDoor;

    private GameObject[] nextPoints = new GameObject[Settings.STARTNUMOFPOINTS];
    private Vector3[] direction = new Vector3[3];

   
    private int lastDirection; 
    private bool m_startBuild;

    private int biomsCount = 1;

    private Settings m_settings;
    private CartMovement m_cartMovement;

    private void Awake()
    {
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonCart"), Vector3.zero, Quaternion.identity);

    }

    private void Start()
    {
        
        m_cart = GameObject.FindGameObjectWithTag("Cart");
        m_settings = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Settings>();
        m_cartMovement = m_cart.GetComponent<CartMovement>();
    }

    private void FixedUpdate()
    {
        if (nextPoints[0] != null && m_startBuild)
        {
            if (m_cartMovement.CartMove(nextPoints[0]))
            {
                if (biomsCount % 3 == 0)
                {
                    biomsCount++;
                    CreteNewNextPoint(nextPointPrefabExit);
                }
                else
                {
                    biomsCount++;
                    CreteNewNextPoint(nextPointPrefabLeft[Random.Range(0, nextPointPrefabLeft.Length)]);
                }

                if (biomsCount == 5)
                {
                    StopBuild();
                }
            }
        }
    }

    public void PreparePathBuilder()
    {
        m_startBuild = false;
       
        lastDirection = -1;
        direction[0] = Vector3.up;
        direction[1] = Vector3.right;
        direction[2] = Vector3.down;


        m_exitDoor.SetActive(true);
        for (int i = 0; i < Settings.STARTNUMOFPOINTS; i++)
        {
            if (nextPoints[i] != null)
            {
                Destroy(nextPoints[i]);
            }
        }

        Vector3 positionToSpawn = Vector3.zero;
        for (int i = 0; i < Settings.STARTNUMOFPOINTS; i++)
        {
            int newLastDirection = 1;

            nextPoints[i] = PhotonNetwork.Instantiate
                            (
                                Path.Combine("PhotonPrefabs", "leftDefault"),
                                positionToSpawn + Settings.STARTDISTANCE * direction[newLastDirection],
                                Quaternion.identity
                            );

            lastDirection = newLastDirection;
            positionToSpawn = nextPoints[i].transform.position;
        }
    }

    

    public void StartBuild()
    {
        if (!m_startBuild)
        {
            m_exitDoor.SetActive(false);
        }
        m_startBuild = true;
    }

    public void StopBuild()
    {
        m_startBuild = false;
        m_cartMovement.SetCartSpeed(0);
    }

    private void CreteNewNextPoint(GameObject biomToSpawn)
    {
        Destroy(nextPoints[0], 1 / Settings.STATRCARTSPEED);
        for (int i = 0; i < Settings.STARTNUMOFPOINTS - 1; i++)
        {
            nextPoints[i] = nextPoints[i + 1];
        }
                
        int newLastDirection = Random.Range(0, 3);
        while (newLastDirection == 0 && lastDirection == 2 || newLastDirection == 2 && lastDirection == 0)
        {
            newLastDirection = Random.Range(0, 3);
        }

        switch (newLastDirection)
        {
            case 0:
                nextPoints[Settings.STARTNUMOFPOINTS - 1] = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", biomToSpawn.name), nextPoints[Settings.STARTNUMOFPOINTS - 2].transform.position + Settings.STARTDISTANCE * direction[newLastDirection], Quaternion.Euler(0f,0f, 90f));
                break;
            
            case 1:
                nextPoints[Settings.STARTNUMOFPOINTS - 1] = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", biomToSpawn.name), nextPoints[Settings.STARTNUMOFPOINTS - 2].transform.position + Settings.STARTDISTANCE * direction[newLastDirection], Quaternion.identity);
                break;
            
            case 2 :
                nextPoints[Settings.STARTNUMOFPOINTS - 1] = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", biomToSpawn.name), nextPoints[Settings.STARTNUMOFPOINTS - 2].transform.position + Settings.STARTDISTANCE * direction[newLastDirection], Quaternion.Euler(0f,0f, -90f));
                break;
        }
        
        lastDirection = newLastDirection;
    }
} 

