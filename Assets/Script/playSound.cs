using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{

    public static playSound instance;

    public AudioSource Soruce;
    public AudioSource AlreatSouce;
    public AudioSource DashSource;
    public AudioClip hurt, shooting,enemyGothit,alreat,dash,button;
    bool Paused;
 

    private void Awake()
    {
        instance = this;

    }

    public void PlayHurt()
    {
        Soruce.clip = hurt;
        Soruce.Play();
    }
    public void Playshooting()
    {
        Soruce.clip = shooting;
        Soruce.Play();
    }

    public void PlayenemyGothit()
    {
        Soruce.clip = enemyGothit;
        Soruce.Play();
    }

    public void PlayAleart()
    {
        if (!Paused)
        {
            AlreatSouce.clip = alreat;
            AlreatSouce.Play();
        }
    }

    public void StopPlayAlreat()
    {
        AlreatSouce.Stop();
    }

    public void PausedAlaret(bool Check)
    {
        if (Check)
        {
            Paused = true;
            StopPlayAlreat();
        }
        else if(!Check)
        {
            Paused = false;
        }
    }

    public void PlayDash()
    {
        DashSource.clip = dash;
        DashSource.Play();
    }

    public void PlayClick()
    {
        Soruce.clip = button;
        Soruce.Play();
    }

    

    




}
