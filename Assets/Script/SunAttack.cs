using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAttack : MonoBehaviour
{
    Transform Player;
    [SerializeField] private string Name = "Heat Planet";
    [SerializeField] private float Range = 15;
    [SerializeField] private float NotiRange = 20;

    float time;
    [SerializeField] public float PlayDelay;

    [SerializeField] public float AttackDelay = 1;
    float Delay;

    bool PlayerIn;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(Player.transform.position, this.transform.position) > Range && Vector2.Distance(Player.transform.position, this.transform.position) < NotiRange)
        {
            PlayerIn = true;

            GameStat.instance.OnStatchange(GameStat.status.Danger);
            SetDangerZoneText.instacen.NamePlante(Name);
            SetDangerZoneText.instacen.ShowDistance(Vector2.Distance(Player.transform.position, this.transform.position), Range);
            if (time <= 0)
            {
                playSound.instance.PlayAleart();
                time = PlayDelay;
            }
        }


       else if(Vector2.Distance(Player.transform.position,this.transform.position) < Range)
        {
            SetDangerZoneText.instacen.ShowDistance(Vector2.Distance(Player.transform.position, this.transform.position), Range);
            SetDangerZoneText.instacen.NamePlante(Name);
            if (Delay <= 0)
            {
                PlayerHealth.instace.TakeDamge();
                Delay = AttackDelay;
            }
            if (time <= 0)
            {
                playSound.instance.PlayAleart();
                time = PlayDelay;
            }
        }

    else
        {
            time = 0;
            if (PlayerIn == true)
            {
                PlayerIn = false;
                GameStat.instance.OnStatchange(GameStat.status.none);
                playSound.instance.StopPlayAlreat();
            }
            
        }

        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        if(Delay > 0)
        {
            Delay -= Time.deltaTime;
        }
                
    }





}
