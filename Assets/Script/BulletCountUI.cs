using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletCountUI : MonoBehaviour
{
    public static BulletCountUI instance;
    public Text AmmoText;

    private void Awake()
    {
        instance = this;
    }

    public void SetUI(int CurrentAmmo,int MaxAmmo)
    {
        AmmoText.text = "Ammo " + CurrentAmmo.ToString() + "/" + MaxAmmo.ToString();
    }

    public void Reloading()
    {
        AmmoText.text = "reloading . . .";
    }
}
