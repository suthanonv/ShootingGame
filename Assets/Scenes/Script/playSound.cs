using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HealthStat
{
    none,
    Max,
    medium,
    low,
    Death
}

public class playSound : MonoBehaviour
{

    public static playSound instance;

    public AudioSource Soruce;
    public AudioSource AlreatSouce;
    public AudioSource DashSource;
    public AudioSource LowHealthSound;
    public AudioClip hurt, shooting,enemyGothit,alreat,dash,button;
    bool Paused;

    [SerializeField] List<GameObject> AudioReverb = new List<GameObject>();
    public GameObject LowHealthImage;
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

    HealthStat stat = HealthStat.none;
    public void OnLowHealth(HealthStat curretnstat)
    {

        if (stat != curretnstat)
        {
            stat = curretnstat;
            if (stat == HealthStat.low)
            {
                LowHealthImage.SetActive(true);
                LowHealthSound.Play();
                foreach (GameObject i in AudioReverb)
                {
                    i.GetComponent<AudioReverbFilter>().enabled = true;
                }
            }
            else
            {
                LowHealthImage.SetActive(false);
                LowHealthSound.Pause();
                foreach (GameObject i in AudioReverb)
                {
                    i.GetComponent<AudioReverbFilter>().enabled = false;
                }
            }
        }
        

    }
    




}
