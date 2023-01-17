using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipStat : ScriptableObject
{
[SerializeField] public int[] Health = new int[5];
 [SerializeField] public int[] Armor = new int[5];
 [SerializeField] public int[] Speed = new int[5];
}
