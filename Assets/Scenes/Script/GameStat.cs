using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : MonoBehaviour
{
    public static GameStat instance;

    status CurrestState = status.none;
    public Transform Fream;
  public  GameObject DangerIcon;


    private void Awake()
    {
        instance = this;
    }


    public enum status
    {
        none,
        Danger,

    }
        
       public void OnStatchange(status stat)
    {
        if(stat != CurrestState)
        {
            CurrestState = stat;
            StatTrigger();
        }
    }


   void StatTrigger()
    {
        switch(CurrestState)
        {
            case status.Danger:
                Instantiate(DangerIcon, Fream.transform);
                break;
            case status.none:
                foreach(Transform i in Fream)
                {
                    Destroy(i.gameObject);
                }
                break;
        }
    }
}
