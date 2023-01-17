using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] public ItemBuff Stat;
    public string Name;
    public string[] Description; 
   

}
