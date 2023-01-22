using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text roomName;
    LobbyManage manager;

    private void Start()
    {
        manager = FindObjectOfType<LobbyManage>();
    }
    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName.ToString();
    }

   public void OnCLikcItem()
    {
        manager.JoinRoom(roomName.text);
    }
}