using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomController : MonoBehaviour
{
    public int Index;

    private bool rotateRight = false;
    private bool rotateLeft = false;

    public Tilemap tilemap;
    Vector3Int currentCell;
    private void Start()
    {
        if (Index == 4)
            currentCell = tilemap.WorldToCell(new Vector3Int(65,0,0));
    }
    public void RotateRoom()
    {
        StartCoroutine("Rotate");
    }

    public void DoSomothing1()
    {
        switch (Index)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                RotateLeft();
                break;
            case 4:
                StartCoroutine("Destroy");
                break;
        }
    }
    public void DoSomothing2()
    {
        switch (Index)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                RotateRight();
                break;
        }
    }

    private void Update()
    {

        if (rotateRight)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime);

        if (rotateLeft)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime);
    }


    private void RotateLeft()
    {
        rotateRight = false;
        rotateLeft = true;
    }

    private void RotateRight()
    {
        rotateRight = true;
        rotateLeft = false;
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(.03f);

        Vector3Int random = new Vector3Int(currentCell.x + Random.Range(-11, 11), currentCell.y + Random.Range(-11, 11), 0);
        tilemap.SetTile(random, null);
        StartCoroutine("Destroy");
    }
}
