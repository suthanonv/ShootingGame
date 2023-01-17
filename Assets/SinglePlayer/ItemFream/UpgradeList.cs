using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UpgradeList : ScriptableObject
{
    [SerializeField] public List<Upgrade> AllUpgrade = new List<Upgrade>();
}
