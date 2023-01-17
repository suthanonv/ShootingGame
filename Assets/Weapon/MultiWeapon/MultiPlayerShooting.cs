using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MultiPlayerShooting : MonoBehaviour
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

    PhotonView view;

    Transform player;
    void Start()
    {
      
        CurrentBullet = BulletCount;
        MultiBulletCount.instance.SetUI(CurrentBullet, BulletCount);
    }

    void Update()
    {
        if (view.IsMine)
        {
            if (CurrentBullet > 0)
            {
                if (CurrentTime <= 0)
                {

                    if (Input.GetMouseButton(0))
                    {
                        float ran = Random.Range(0, SpeardRange);
                        playSound.instance.Playshooting();
                        ran = RandomBetweenNumber(-ran, ran);

                        Vector3 SpawnPoint = new Vector3(Point.transform.position.x + ran, Point.transform.position.y, Point.transform.position.z);

                        GameObject projectile = Instantiate(Bullet, SpawnPoint, Point.transform.rotation);
                        projectile.GetComponent<SetPhoTonView>().SetView(view);
                        projectile.GetComponent<MultiBulletCollider>().SetTransfrom(player);
                        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

                        rb.AddForce(Point.up * Force, ForceMode2D.Impulse);

                        CurrentBullet--;
                        MultiBulletCount.instance.SetUI(CurrentBullet, BulletCount);


                        if (CurrentBullet <= 0)
                        {
                            CurrentReloadTime = ReloadTime;
                        }
                        CurrentTime = AttackCoolDown;
                    }
                }
                else
                {

                    CurrentTime -= Time.deltaTime;
                }
            }
            else
            {
                CurrentReloadTime -= Time.deltaTime;
                MultiBulletCount.instance.Reloading();

                if (CurrentReloadTime <= 0)
                {
                    MultiBulletCount.instance.SetUI(CurrentBullet, BulletCount);
                    CurrentBullet = BulletCount;
                    CurrentTime = 0;

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
    }

    float RandomBetweenNumber(float Num1, float Num2)
    {
        int ran = Random.Range(0, 2);

        if (ran == 1)
        {
            return Num1;
        }
        else
        {
            return Num2;
        }
    }


    public void SetViewPothon(PhotonView View)
    {
        view = View;
    }

    public void SetPlayer(Transform newPlyer)
    {
        player = newPlyer;
    }

}
