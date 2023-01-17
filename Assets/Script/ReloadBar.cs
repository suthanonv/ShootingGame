using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReloadBar : MonoBehaviour
{
    public static ReloadBar instance;
    public Slider relordbar;
    public GameObject Bar;
    private void Awake()
    {
        instance = this;
    }

    public void ReloadingBar(float CurrentTime, float MaxTIme)
    {
        relordbar.maxValue = MaxTIme;
        relordbar.value = CurrentTime;

        if (CurrentTime > 0)
        {
            Bar.SetActive(true);
        }
        else
        {
            Bar.SetActive(false);
        }
    }
}
