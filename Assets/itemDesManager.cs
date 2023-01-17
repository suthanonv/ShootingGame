using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDesManager : MonoBehaviour
{
    public static itemDesManager instance;

    [SerializeField] ItemDes itemPrefab;
    [SerializeField] Transform itemContent;
    public GameObject Panel;
    int Count;

    [SerializeField] OverAllStat stat;

    private void Awake()
    {
        instance = this;
    }

    public void GetNewItem(Item newItem)
    {
        CursorLock.instance.MouseLockCheck(false);
        PausedManage.instace.currentStat = PuasedStat.Paused;
        Panel.SetActive(true);
        Time.timeScale = 0;
        ItemDes item = Instantiate(itemPrefab, itemContent.transform);
        item.SetUI(newItem);
        Count++;
    }

    public void UseItem(Item newItem)
    {
        Count--;

        SetStatus(newItem);
        ChangeStatus();

        if (Count <=0)
        {
            CursorLock.instance.MouseLockCheck(true);
            Panel.SetActive(false);
            PausedManage.instace.currentStat = PuasedStat.none;
            Time.timeScale = 1;
        }
      
    }

    public void RejectItem()
    {
        Count--;
        if (Count <= 0)
        {
            CursorLock.instance.MouseLockCheck(true);
            Panel.SetActive(false);
            PausedManage.instace.currentStat = PuasedStat.none;
            Time.timeScale = 1;
        }
    }

    void SetStatus(Item thisitem)
    {
        stat.Ammo += thisitem.Stat.Ammo;
        stat.CurrentHealth += thisitem.Stat.Health;
        stat.CurrentArmor += thisitem.Stat.Armor;
        stat.BulletDamage += thisitem.Stat.DamageBuff;
        stat.BulletPiercing += thisitem.Stat.BulletPiecing;
        stat.BulletSpeed += thisitem.Stat.BulletSpeed;
        stat.WalkSpeed += thisitem.Stat.PlayerWalkSpeed;
        stat.ReloadSpeed += thisitem.Stat.ReloadSpeed;
        stat.PickUpRange += thisitem.Stat.PickUpRange;
        stat.AttackSpeed += thisitem.Stat.AttackSpeed;

    }
  

    void ChangeStatus()
    {

        GameObject Player = GameObject.FindWithTag("Player");
        Player.GetComponent<PlayerHealth>().OnStatusChnage();
        Player.GetComponent<Walk>().OnStatusChnage();

        ShotGUn shortGun = GameObject.FindObjectOfType<ShotGUn>();
        if (shortGun != null)
        {
            shortGun.OnStatusChnage();
        }
        Shooting Gun = GameObject.FindObjectOfType<Shooting>();
        if (Gun != null)
        {
            Debug.Log("Run");
            Gun.OnStatusChnage();
        }
        GameObject[] chest = GameObject.FindGameObjectsWithTag("Chest");

        foreach(GameObject i in chest)
        {
            if(i !=null)
            {
                i.GetComponent<ChestOpened>().OnStatusChange();
            }
        }
    }



}
