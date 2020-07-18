using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
    [SerializeField]
    private Transform _exitPoint;
    private GameObject _player;
    public int NextIndex;
    private RoomManager roomManager;

    public static bool canTeleport = false;

    private void Awake()
    {
        roomManager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Teleport()
    {
        if (canTeleport | NextIndex == 4)
        {
            if (NextIndex != 0)
                roomManager.Activate(NextIndex);
            _player.transform.position = _exitPoint.position;
            canTeleport = false;
        }
        else
        {
            switch (NextIndex)
            {
                case 2:
                    DialogueController.DialogueShow("The door is locked. Find the key under the blue flag", null);
                    break;
                case 3:
                    DialogueController.DialogueShow("To go further, you need to kill all the bugs!", null);
                    break;
            }
            
        }
    }
}
