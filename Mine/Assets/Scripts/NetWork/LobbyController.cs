using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject lobbyConnectButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject lobbyPanel;
    [SerializeField] private GameObject mainPanel;

    public InputField playernameInput;
    public InputField roomNameInput;
    public InputField roomSizeInput;

    private string roomName;
    private int roomSize;

    private List<RoomInfo> roomListings;

    [SerializeField] private Transform roomsContainer;
    [SerializeField] private GameObject roomListingPrefab;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        lobbyConnectButton.SetActive(true);
        roomListings = new List<RoomInfo>();

        if (roomNameInput.text == "")
        {
            roomName = "Room" + Random.Range(0, 1000);
        } else
        {
            roomName = roomNameInput.text;
        }

        if (roomSizeInput.text == "")
        {
            roomSize = 1;
        }
        else
        {
            if (int.Parse(roomSizeInput.text) <= 0)
            {
                roomSize = 1;
            }
            else
            {
                roomSize = int.Parse(roomSizeInput.text);
            }
        }


        if (playernameInput.text == "")
        {
            PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
        }
        else
        {
            PhotonNetwork.NickName = playernameInput.text;
        }
    }

    public void PlayerNameUpdate(string nameInput)
    {
        PhotonNetwork.NickName = nameInput;
    }

    public void JoinLobbyOnClick()
    {
        mainPanel.SetActive(false);
        lobbyPanel.SetActive(true);
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int tempIndex;

        foreach(RoomInfo room in roomList)
        {
            if (roomListings != null)
            {
                tempIndex = roomListings.FindIndex(ByName(room.Name));
            }
            else
            {
                tempIndex = -1;
            }
            if (tempIndex != -1)
            {
                roomListings.RemoveAt(tempIndex);
                Destroy(roomsContainer.GetChild(tempIndex).gameObject);

            }
            if (room.PlayerCount > 0)
            {
                roomListings.Add(room);
                ListRoom(room);
            }
        }
    }

    static System.Predicate<RoomInfo> ByName(string name)
    {
        return delegate (RoomInfo room)
        {
            return room.Name == name;
        };
    }

    void ListRoom(RoomInfo room)
    {
        if (room.IsOpen && room.IsVisible)
        {
            GameObject tempListing = Instantiate(roomListingPrefab, roomsContainer);
            RoomButton tempButton = tempListing.GetComponent<RoomButton>();
            tempButton.SetRoom(room.Name, room.MaxPlayers, room.PlayerCount);
        }
    }

    public void OnRoomNameChanged(string nameIn)
    {
        if (nameIn == "")
        {
            roomName = "Room" + Random.Range(0, 1000);
        }
        else
        {
            roomName = nameIn;
        } 
    }
    public void OnRoomSizeChanged(string sizeIn)
    {
        if (int.Parse(sizeIn) <= 0)
        {
            roomSize = 1;
        }
        else
        {
            roomSize = int.Parse(sizeIn);
        }
    }
    
    public void CreateRoom()
    {
        Debug.Log("Creating new room...");
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom(roomName, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed((");
    }

    public void MatchMakingCancel()
    {
        mainPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        PhotonNetwork.LeaveLobby();
    }

    public void ExitOnClick()
    {
        Application.Quit(0);
    }
}
