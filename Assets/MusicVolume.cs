using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicVolume : MonoBehaviour
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
        MusicSlider.value = PlayerPrefs.GetFloat("Music");
        Valuetext.text = MusicSlider.value.ToString("#.##");
        Music.volume = MusicSlider.value;
    }

    public void SetVolume()
    {
        PlayerPrefs.SetFloat("Music", MusicSlider.value);
        Valuetext.text = MusicSlider.value.ToString("#.##");
        Music.volume = MusicSlider.value;

    }
}
