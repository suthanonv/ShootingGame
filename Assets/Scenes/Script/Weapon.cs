using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
   [SerializeField] public Sprite Icon;
    [SerializeField] public string WeaponName;
    [SerializeField] public GameObject WeaponPrefab;
    [SerializeField] public Weapon[] NextWeapon;
    [SerializeField] public int PointCost; 
}
