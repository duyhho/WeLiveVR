using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class RoomManager : MonoBehaviourPunCallbacks
{
    string mapType;
    public TextMeshProUGUI OccupancyRateText_Outdoor;
    public TextMeshProUGUI OccupancyRateText_School;
    public TextMeshProUGUI OccupancyRateText_Clinic;
    public TextMeshProUGUI OccupancyRateText_Meeting;
    public TextMeshProUGUI OccupancyRateText_Classroom;
    public TextMeshProUGUI OccupancyRateText_XRroom;





    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinLobby();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region UI Callback Methods
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }



    #endregion

    #region Photon Callback Methods
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server again!");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoinRoom();
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("A room is created - Name: " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("The Local player: " + PhotonNetwork.NickName + "joined " + PhotonNetwork.CurrentRoom.Name + " - Player Count:" + PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstants.MAP_TYPE_KEY))
        {
            object mapType;
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("map", out mapType))
            {
                Debug.Log("Joined room map: " + (string)mapType);
            }

            if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL)
            {
                PhotonNetwork.LoadLevel("World_School Multiplayer");
            }
            else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR)
            {
                PhotonNetwork.LoadLevel("World_Outdoor Multiplayer");

            }
            else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_CLINIC)
            {
                PhotonNetwork.LoadLevel("Clinic Multiplayer");

            }
            else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_DREAM1)
            {
                PhotonNetwork.LoadLevel("Dream1 Multiplayer");

            }
            else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_DREAM2)
            {
                PhotonNetwork.LoadLevel("Dream2 Multiplayer");

            }
            else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_DREAM3)
            {
                PhotonNetwork.LoadLevel("Dream3 Multiplayer");

            }
            else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_DREAM4)
            {
                PhotonNetwork.LoadLevel("Dream4 Multiplayer");

            }
            else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_MEETING)
            {
                PhotonNetwork.LoadLevel("Meeting Multiplayer");

            }
            else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_CLASSROOM)
            {
                PhotonNetwork.LoadLevel("Classroom Multiplayer");

            }
            else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_XR_ROOM)
            {
                PhotonNetwork.LoadLevel("XR_Room");

            }
        }
    }
    public void OnEnterButtonClicked_Outdoor()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    public void OnEnterButtonClicked_School()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    public void OnEnterButtonClicked_Clinic()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_CLINIC;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    public void OnEnterButtonClicked_Dream1()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_DREAM1;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    public void OnEnterButtonClicked_Dream2()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_DREAM2;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    public void OnEnterButtonClicked_Dream3()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_DREAM3;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    public void OnEnterButtonClicked_Dream4()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_DREAM4;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    public void OnEnterButtonClicked_Meeting()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_MEETING;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    public void OnEnterButtonClicked_Classroom()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_CLASSROOM;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    public void OnEnterButtonClicked_XRroom()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_XR_ROOM;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " just joined! Current Player Count:" + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (roomList.Count == 0)
        {
            Debug.Log("There is no room");

            //There is no room
            OccupancyRateText_School.text = 0 + " / " + 20;
            OccupancyRateText_Outdoor.text = 0 + " / " + 20;
            OccupancyRateText_Clinic.text = 0 + " / " + 20;

        }
        foreach (RoomInfo room in roomList)
        {
            Debug.Log(room.Name + " Player Count: " + room.PlayerCount);
            if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR))
            {
                //Update the Outdoor room occupancy field
                OccupancyRateText_Outdoor.text = room.PlayerCount + " / " + 20;
            }
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL))
            {
                Debug.Log("Room is School. Player count is: " + room.PlayerCount);
                OccupancyRateText_School.text = room.PlayerCount + " / " + 20;
            }
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_CLINIC))
            {
                Debug.Log("Room is Clinic. Player count is: " + room.PlayerCount);
                OccupancyRateText_Clinic.text = room.PlayerCount + " / " + 20;
            }
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_MEETING))
            {
                Debug.Log("Room is Meeting. Player count is: " + room.PlayerCount);
                OccupancyRateText_Meeting.text = room.PlayerCount + " / " + 20;
            }
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_CLASSROOM))
            {
                Debug.Log("Room is Classroom. Player count is: " + room.PlayerCount);
                OccupancyRateText_Classroom.text = room.PlayerCount + " / " + 20;
            }
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_XR_ROOM))
            {
                Debug.Log("Room is Classroom. Player count is: " + room.PlayerCount);
                OccupancyRateText_XRroom.text = room.PlayerCount + " / " + 20;
            }


        }

    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined the Lobby " + PhotonNetwork.ServerAddress );
        Debug.Log("Count of Player on Master: "+ PhotonNetwork.CountOfPlayersOnMaster);
        Debug.Log("Count of Players: "+ PhotonNetwork.CountOfPlayers);

    }
    #endregion

    #region Private Methods
    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room_" + mapType + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        //RoomOptions has multiple options to choose from (e.g isOpen, isVisible, MaxPlayers)
        roomOptions.MaxPlayers = 20;

        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        string[] roomPropsInLobby = { "map" };
        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby;
        roomOptions.CustomRoomProperties = customRoomProperties;

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);


    }
    #endregion
}

