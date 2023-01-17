using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class ItemBuff
{
    public float DamageBuff;
    public float BulletSpeed;
    public float PlayerWalkSpeed;
    public float PickUpRange;
    public float BulletPiecing;
    public float AttackSpeed;
    public float ReloadSpeed;
    public int Ammo;
    public int Armor;
    public int Health;
    

    public ItemBuff(float DamageBuff,float BulletSpeed,float PlayerWalkSpeed,float PickUpRange,float BulletPiecing,int Armor,int Health, float AttackSpeed, int Ammo,float ReloadSpeed)
    {
        this.DamageBuff = DamageBuff;
        this.BulletSpeed = BulletSpeed;
        this.PlayerWalkSpeed = PlayerWalkSpeed;
        this.PickUpRange = PickUpRange;
        this.BulletPiecing = BulletPiecing;
        this.Armor = Armor;
        this.Health = Health;
        this.AttackSpeed = AttackSpeed;
        this.Ammo = Ammo;
        this.ReloadSpeed = ReloadSpeed;
    }
     

}
