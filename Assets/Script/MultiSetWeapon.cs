using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MultiSetWeapon : MonoBehaviour
{
    [SerializeField] private Weapon CurrentWeapon;
    public PhotonView view;
    public Transform PlayerTransfrom;
    private void Start()
    {
        SettingWeapon(CurrentWeapon);
    }

    public void SettingWeapon(Weapon ChangeWeapon)
    {
        CurrentWeapon = ChangeWeapon;

        foreach (Transform i in this.transform)
        {
            Destroy(i.gameObject);
        }
    GameObject wope =     Instantiate(CurrentWeapon.WeaponPrefab, this.transform);
        wope.GetComponent<MultiPlayerShooting>().SetViewPothon(view);
           
    }
}