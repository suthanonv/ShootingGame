using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public static Sound Instace;

    [SerializeField] AudioSource SoundSouce;
    [SerializeField] AudioClip ButtonHover, CLick;

    private void Awake()
    {
        Instace = this;
    }

    private void Start()
    {
        SetSound();
    }

    public void PlayHover()
    {
        SoundSouce.clip = ButtonHover;
        SoundSouce.Play();
    }

    public void PLayClick()
    {
        SoundSouce.clip = CLick;
        SoundSouce.Play();
    }

    void SetSound()
    {
        if(PlayerPrefs.GetInt("FristTime") == 0)
        {
            PlayerPrefs.SetInt("FristTime", 1);
            PlayerPrefs.SetFloat("Music",1);
            PlayerPrefs.SetFloat("Sounds", 1);
        }
    }

}
