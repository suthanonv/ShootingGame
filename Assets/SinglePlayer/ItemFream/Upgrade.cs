using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Upgrade : ScriptableObject
{
    public string Name;
    public Sprite UpgradeSprite;
    public float CurrentLv;
    public string Des;
    public OverAllStat Stat;
    [SerializeField] public int CurrentLV;
[SerializeField]  public int[] Cost = new int[0];

 
}
