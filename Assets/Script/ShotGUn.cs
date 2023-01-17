using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGUn : MonoBehaviour , StatusChaned
{
    public KeyCode key = KeyCode.R;

    public Transform[] Point;
    public GameObject Bullet;

    [SerializeField] private float AttackCoolDown;
    [SerializeField] private float Force;
    float CurrentTime;

    [SerializeField] public int BulletCount;
    int CurrentBullet;

    [SerializeField] public float ReloadTime;
    float CurrentReloadTime;

    [SerializeField] OverAllStat stat;

    float CurrentAmmoPlus;
    float CurrentSpeedPlus;
    float CurrentReloadPlus;
    float CurrentAttackSpeedPlus;

    void Awake()
    {
        if (CurrentAmmoPlus != stat.Ammo)
        {
            BulletCount += stat.Ammo;
            CurrentAmmoPlus = stat.Ammo;
        }
        if (CurrentSpeedPlus != stat.BulletSpeed)
        {
            CurrentSpeedPlus = stat.BulletSpeed;
            Force += Force * stat.BulletSpeed;
        }
        if (CurrentReloadPlus != stat.ReloadSpeed)
        {
            CurrentReloadPlus = stat.ReloadSpeed;
            ReloadTime -= ReloadTime * stat.ReloadSpeed;
        }
        if (CurrentAttackSpeedPlus != stat.AttackSpeed)
        {
            CurrentAttackSpeedPlus = stat.AttackSpeed;
            AttackCoolDown -= AttackCoolDown * stat.AttackSpeed;
        }

    }


    void Start()
    {
        ReloadBar.instance.ReloadingBar(0, 1);
        CurrentBullet = BulletCount;
        BulletCountUI.instance.SetUI(CurrentBullet, BulletCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentBullet > 0)
        {
            if (CurrentTime <= 0)
            {
                CursorLock.instance.MouseChange(false);
                if (Input.GetMouseButton(0) && PausedManage.instace.currentStat != PuasedStat.Paused)
                {

                    for (int i = 0; i < Point.Length;)
                    {
                        GameObject projectile = Instantiate(Bullet, Point[i].transform.position, Point[i].transform.rotation);
                        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                        rb.AddForce(Point[i].up * Force, ForceMode2D.Impulse);
                        i++;
                    }
                    CurrentBullet--;
                    BulletCountUI.instance.SetUI(CurrentBullet, BulletCount);

                    if (CurrentBullet <= 0)
                    {
                        CurrentReloadTime = ReloadTime;
                    }
                    CurrentTime = AttackCoolDown;
                }
            }
            else
            {
                CursorLock.instance.MouseChange(true);
                CurrentTime -= Time.deltaTime;
            }
        }
        else
        {
            CurrentReloadTime -= Time.deltaTime;
           
            BulletCountUI.instance.Reloading();
            ReloadBar.instance.ReloadingBar(CurrentReloadTime, ReloadTime);

            if (CurrentReloadTime <= 0)
            {

                CurrentBullet = BulletCount;
         
                BulletCountUI.instance.SetUI(CurrentBullet, BulletCount);
            }
        }

        if (Input.GetKey(key))
        {
            if (CurrentReloadTime <= 0 && CurrentBullet != 0 && CurrentBullet != BulletCount)
            {
                CurrentBullet = 0;
                CurrentReloadTime = ReloadTime;
            }
        }
    }

    public void OnStatusChnage()
    {
        Debug.Log("Change");
        if (CurrentAmmoPlus != stat.Ammo)
        {
            BulletCount += stat.Ammo;
            CurrentAmmoPlus = stat.Ammo;
            BulletCountUI.instance.SetUI(CurrentBullet, BulletCount);
        }
        if (CurrentSpeedPlus != stat.BulletSpeed)
        {
            CurrentSpeedPlus = stat.BulletSpeed;
            Force += Force * stat.BulletSpeed;
        }
        if (CurrentReloadPlus != stat.ReloadSpeed)
        {
            CurrentReloadPlus = stat.ReloadSpeed;
            ReloadTime -= ReloadTime * stat.ReloadSpeed;
        }
        if (CurrentAttackSpeedPlus != stat.AttackSpeed)
        {
            CurrentAttackSpeedPlus = stat.AttackSpeed;
            AttackCoolDown -= AttackCoolDown * stat.AttackSpeed;
        }
    }

}
