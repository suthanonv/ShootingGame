using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFream : MonoBehaviour
{

     Weapon thisWeapon;

    public void OnClick()
    {
        PointManage.instance.ClosePanal();
        SetWeapon.instace.SettingWeapon(thisWeapon);
        Debug.Log("Click");
     }

    public void GetWeapon(Weapon newWeapon)
    {
        thisWeapon = newWeapon;
    }



}
