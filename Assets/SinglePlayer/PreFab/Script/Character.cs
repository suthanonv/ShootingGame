using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public int ChatacterID;

  [SerializeField]  public GameObject CharacterPreFab;
    public ShipStat Stat;
    public string CharacterName;
    public ShipDes Des;
    public Sprite Icon;
    public int ChracterCost;
    [SerializeField] public bool isUnlock;
    [SerializeField] public int CurrentLv;
    [SerializeField] public int[] UpgradeCost = new int[5];
}
