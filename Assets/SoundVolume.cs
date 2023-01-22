using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundVolume : MonoBehaviour
{
    [SerializeField] AudioSource Music;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Text Valuetext;


    private void Start()
    {
        LoadVolume();
    }

    void LoadVolume()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("Sound");
        Valuetext.text = MusicSlider.value.ToString("#.##");
        Music.volume = MusicSlider.value;
    }

    public void SetVolume()
    {
        PlayerPrefs.SetFloat("Sounds", MusicSlider.value);
        Valuetext.text = MusicSlider.value.ToString("#.##");
        Music.volume = MusicSlider.value;
    }
}
