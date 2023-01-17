using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OverAllStat : ScriptableObject
{
    public int CurrentHealth;
    public int CurrentArmor;
    public  int Ammo; // PlusAmmo 
    public float AttackSpeed; 
    public float WalkSpeed; //SpaceShip WalkSpeed;
    public float BulletSpeed; // * Percent
    public float BulletPiercing; // * Percent
    public float BulletDamage; // * Percent
    public float PickUpRange; // * Percent
    public float ReloadSpeed;


}
