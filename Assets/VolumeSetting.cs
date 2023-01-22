using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeSetting : MonoBehaviour
{
    [SerializeField] AudioSource[] Sound;
    [SerializeField] AudioSource Music;
    [SerializeField] Text SoundValue, MusicValue;
    [SerializeField] Slider SoundSLider, MusicSLider;

     void Start()
    {
        LoadVolume();
    }

    void LoadVolume()
    {
       foreach(AudioSource i in Sound)
        {
            i.volume = PlayerPrefs.GetFloat("Sound");
        }
        
        Music.volume = PlayerPrefs.GetFloat("Music");
        SoundSLider.value = PlayerPrefs.GetFloat("Sound");
        MusicSLider.value = PlayerPrefs.GetFloat("Music");
        SoundValue.text = SoundSLider.value.ToString("#.##");
        MusicValue.text = SoundSLider.value.ToString("#.##");
    }

    public void SetSound()
    {
        PlayerPrefs.SetFloat("Sound", SoundSLider.value);
        foreach (AudioSource i in Sound)
        {
            i.volume = PlayerPrefs.GetFloat("Sound");
        }
        SoundValue.text = SoundSLider.value.ToString("#.##");
    }
    public void SetMusic()
    {
        PlayerPrefs.SetFloat("Music", MusicSLider.value);
        Music.volume = PlayerPrefs.GetFloat("Music");
        MusicValue.text = MusicSLider.value.ToString("#.##");
    }
}

