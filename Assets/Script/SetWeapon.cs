using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWeapon : MonoBehaviour
{
    public static SetWeapon instace;


[SerializeField] private  Weapon CurrentWeapon;

    private void Awake()
    {
        instace = this;
    }

    private void Start()
    {
        SettingWeapon(CurrentWeapon);
    }

    public void SettingWeapon(Weapon ChangeWeapon)
    {
        CurrentWeapon = ChangeWeapon;

        foreach(Transform i in this.transform)
        {
            Destroy(i.gameObject);
        }

        Instantiate(CurrentWeapon.WeaponPrefab,this.transform);
    }


    public Weapon GetWeapon()
    {
        return CurrentWeapon;
    }





}
