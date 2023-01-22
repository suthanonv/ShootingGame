using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class MultiBulletCount : MonoBehaviour
{
    public static MultiBulletCount instance;
    public Text AmmoText;
    public PhotonView view;
    public GameObject Casvas;
        private void Awake()
    {
        instance = this;
        if(!view.IsMine)
        {
            Casvas.SetActive(false);
        }
    }

    public void SetUI(int CurrentAmmo, int MaxAmmo)
    {
        AmmoText.text = "Ammo " + CurrentAmmo.ToString() + "/" + MaxAmmo.ToString();
    }

    public void Reloading()
    {
        AmmoText.text = "reloading . . .";
    }
}
