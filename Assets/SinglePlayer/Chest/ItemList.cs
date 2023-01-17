using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemList : ScriptableObject
{
    [SerializeField] public List<Item> AlibleItem = new List<Item>();
}
