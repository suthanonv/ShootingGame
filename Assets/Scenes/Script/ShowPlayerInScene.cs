using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class ShowPlayerInScene : MonoBehaviour
{
    public Transform Content;
    public PlayerItem ItemPreFab;
    public GameObject player;


    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;

    private void Awake()
    {
        SpawnPlayer(); 
    }
    void Start()
    {
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem i = Instantiate(ItemPreFab, Content.transform);
            i.SetPlayerInfo(player.Value);
            
        }
        
    }

    void SpawnPlayer()
    {
        Vector2 randomPosition = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
        PhotonNetwork.Instantiate(player.name, randomPosition, Quaternion.identity);
    }
}
