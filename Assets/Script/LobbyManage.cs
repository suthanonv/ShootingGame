using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class LobbyManage : MonoBehaviourPunCallbacks
{
    public InputField inputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text RoomName;

    public RoomItem RoomItemPrefab;
    List<RoomItem> roomitemList = new List<RoomItem>();
    public Transform contentObject;

    [SerializeField] public byte maxPlayer = 4;
    public float timeBetweenUpdate = 1.5f;
    float nextUpdateTime;

    public List<PlayerItem> playeritemList = new List<PlayerItem>();
    public PlayerItem playeritemPrefab;
    public Transform playerItemParent;

    public GameObject playButton;

         
    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }


    public void OnClikcCreate()
    {
        if(inputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(inputField.text, new RoomOptions() { MaxPlayers = maxPlayer });
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        RoomName.text = PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

            UpdateRoomList(roomList);
    }


    private void UpdateRoomList(List<RoomInfo> list)
    {
        foreach(RoomItem i in roomitemList)
        {
            Destroy(i.gameObject);
        }
        roomitemList.Clear();

        foreach(RoomInfo room in list)
        {
   RoomItem newRoom =   Instantiate(RoomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomitemList.Add(newRoom);
        }

    }

    public void  JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
       
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }   

    public void OnClickLeaveLobby()
    {
        PhotonNetwork.LeaveLobby();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    void UpdatePlayerList()
    {
        foreach(PlayerItem item in playerItemParent)
        {
            Destroy(item.gameObject);
        }
        playeritemList.Clear();

        if(PhotonNetwork.CurrentRoom == null)
        {
            return;
        }
        
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem item = Instantiate(playeritemPrefab, playerItemParent);
            item.SetPlayerInfo(player.Value);
            playeritemList.Add(item);
        }
    }

    private void Update()
    {
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 1)
        {
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }

    public void OnClickButtonPlay()
    {
        PhotonNetwork.LoadLevel("MultiPlayer");
    }
}
