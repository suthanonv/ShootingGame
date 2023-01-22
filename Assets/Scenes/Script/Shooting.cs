using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Shooting : MonoBehaviour, StatusChaned
{


    public KeyCode key = KeyCode.R;

    public Transform Point;
    public GameObject Bullet;

    [SerializeField] private float AttackCoolDown;
    [SerializeField] private float Force;
    float CurrentTime;

    [SerializeField] public int BulletCount;
    int CurrentBullet;

    [SerializeField] public float ReloadTime;
    float CurrentReloadTime;

    [SerializeField] public float SpeardRange;

    [SerializeField] OverAllStat stat;


    float CurrentAmmoPlus;
    float CurrentSpeedPlus;
    float CurrentReloadPlus;
    float CurrentAttackSpeedPlus;

    void Awake()
    {
        if(CurrentAmmoPlus != stat.Ammo)
        {
            BulletCount += stat.Ammo;
            CurrentAmmoPlus = stat.Ammo;
        }
        if(CurrentSpeedPlus != stat.BulletSpeed)
        {
            CurrentSpeedPlus = stat.BulletSpeed;
            Force += Force * stat.BulletSpeed;
        }
        if(CurrentReloadPlus != stat.ReloadSpeed)
        {
            CurrentReloadPlus = stat.ReloadSpeed;
            ReloadTime -= ReloadTime * stat.ReloadSpeed;
        }
        if(CurrentAttackSpeedPlus != stat.AttackSpeed)
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
                    float ran = Random.Range(0, SpeardRange);

                    ran = RandomBetweenNumber(-ran, ran);

                    Vector3 SpawnPoint = new Vector3(Point.transform.position.x + ran, Point.transform.position.y, Point.transform.position.z);

                    GameObject projectile = Instantiate(Bullet, SpawnPoint, Point.transform.rotation);
                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    
                    rb.AddForce(Point.up * Force, ForceMode2D.Impulse);
                  
                    CurrentBullet--;

                    playSound.instance.Playshooting();

                    BulletCountUI.instance.SetUI(CurrentBullet, BulletCount);
                   
                    if (CurrentBullet <= 0)
                    {
                        ReloadStart();
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
            CursorLock.instance.MouseChange(true);
            BulletCountUI.instance.Reloading();
            ReloadBar.instance.ReloadingBar(CurrentReloadTime, ReloadTime);
           
            if (CurrentReloadTime <= 0  )
            {
           

                CurrentBullet = BulletCount;
                CurrentTime = 0;
                BulletCountUI.instance.SetUI(CurrentBullet, BulletCount);
            }
        }

        if(Input.GetKey(key))
        {
            if(CurrentReloadTime <= 0 && CurrentBullet != 0 && CurrentBullet != BulletCount)
            {
                ReloadStart();
            }
        }
    }

    void ReloadStart()
    {
        CurrentBullet = 0;
        CurrentReloadTime = ReloadTime;

        ShootEvent.instace.OnStartReload();
    }

    float  RandomBetweenNumber(float Num1,float Num2)
    {
        int ran = Random.Range(0, 2);

        if(ran == 1)
        {
            return Num1;
        }
        else
        {
            return Num2;
        }
    }

    public void OnStatusChnage()
    {
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
