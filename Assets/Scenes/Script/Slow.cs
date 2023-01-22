using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{

    Transform Player;
    [SerializeField] private string Name = "Slow Planet";
    [SerializeField] private float Range = 15;
    [SerializeField] private float NotiRange = 20;

    float time;
    [SerializeField] public float PlayDelay;

    bool PlayerIn;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(Player.transform.position, this.transform.position) > Range && Vector2.Distance(Player.transform.position, this.transform.position) < NotiRange)
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
        else if(Vector2.Distance(Player.transform.position, this.transform.position) <= Range)
        {
            SetDangerZoneText.instacen.NamePlante(Name);
            SetDangerZoneText.instacen.ShowDistance(Vector2.Distance(Player.transform.position, this.transform.position), Range);
            Walk.Instace.CurrentSpeed = 1;

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
                Walk.Instace.NormleSpeed();
                playSound.instance.StopPlayAlreat();
            }
            
            
        }
            
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
    }


}