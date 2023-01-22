using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public enum PuasedStat
     {
        none,Paused
        }
public class PausedManage : MonoBehaviour
{
    public KeyCode key = KeyCode.Escape;
    public GameObject PausedMenu;
    [SerializeField] GameObject Setting;
    [SerializeField] GameObject Menu;
    public static PausedManage instace;

    public PuasedStat currentStat = PuasedStat.none;
   
        

    private void Awake()
    {
        instace = this; 
    }

    


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key) && Time.timeScale == 1)
        {
            CursorLock.instance.MouseLockCheck(false);
            Time.timeScale = 0;
            currentStat = PuasedStat.Paused;
            PausedMenu.SetActive(true);
            Menu.SetActive(true);
            Setting.SetActive(false);
        }
        else if(Input.GetKeyDown(key) && Time.timeScale == 0)
        {
            CursorLock.instance.MouseLockCheck(true);
            Time.timeScale = 1;
            currentStat = PuasedStat.none;
            PausedMenu.SetActive(false);
            Menu.SetActive(true);
            Setting.SetActive(false);
        }
    }
}
