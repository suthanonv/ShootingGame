using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject Paused;
   

    public void OnClick()
    {
        Time.timeScale = 1;
        PausedManage.instace.currentStat = PuasedStat.none;
        CursorLock.instance.MouseLockCheck(true);
        Paused.SetActive(false);
    }
}
