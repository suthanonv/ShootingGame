using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ShootEvent : MonoBehaviour
{
    public static ShootEvent instace;
    public UnityEvent StartReloadEvenet;
    public UnityEvent<GameObject> OnBulletHit;
    private void Awake()
    {
        instace = this;
    }

    public void OnStartReload()
    {
        Debug.Log("Start EVent");
        StartReloadEvenet.Invoke();
    }

    public void BulletHittingEnemy(GameObject enemyHit)
    {
        OnBulletHit.Invoke(enemyHit);
    }

    //        x.StartReloadEvenet.AddListener(OnGunReload);
}
