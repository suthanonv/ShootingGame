using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class TimeCountDown : MonoBehaviour
{
    

    public float MaxMinute;
    float CurrentMinute;
    float CurrentSecond;
    public float PlayTime;

    public Text TimerText;

    bool Stop;
    bool Once = true;

    public UnityEvent clear;

    private void Start()
    {
        CurrentMinute = MaxMinute;
        SetTimer();
    }

    private void Update()
    {
        if (!Stop)
        {
            if (PlayTime < MaxMinute * 60)
            {
                if (CurrentSecond <= 0)
                {
                    CurrentSecond = 60;
                    CurrentMinute -= 1;
                    SetTimer();
                }
                else
                {
                    CurrentSecond -= Time.deltaTime;
                    PlayTime += Time.deltaTime;
                    SetResult.instance.SetTimeer(PlayTime);
                    SetTimer();
                }
            }
            else
            {
                if (Once)
                {
                    Once = false;
                    GameObject.FindObjectOfType<SpawningEnemy>().enabled = false;
                    TimerText.text = "00:00";
                PlayTime = MaxMinute * 60;
                SetResult.instance.SetTimeer(PlayTime);

                    GameObject.FindObjectOfType<PausedManage>().enabled = false;
                    GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
               GameObject[] Bullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
                    GameObject Player = GameObject.FindWithTag("Player");
                    
                    if (Enemy != null)
                    {
                        foreach (GameObject i in Enemy)
                        {
                            i.GetComponent<KnockBack>().PlayFeedBack(Player);
                        }
                    }

                    if (Bullet != null)
                    {
                        foreach (GameObject i in Bullet)
                        {
                            Destroy(i.gameObject);
                        }
                    }
                    GameObject.FindObjectOfType<PausedManage>().enabled = false;
                    clear.Invoke();
                }
            }
        }
    }

    void SetTimer()
    {
       if(CurrentMinute > 9 && CurrentSecond > 9)
        {
            TimerText.text = CurrentMinute.ToString("#") + ":" + CurrentSecond.ToString("#");
        }
      else if(CurrentMinute <= 9 && CurrentSecond > 9)
        {
            TimerText.text = "0" + CurrentMinute.ToString("#") + ":" + CurrentSecond.ToString("#");
        }
       else if(CurrentMinute <= 9 && CurrentSecond <= 9)
        {
            TimerText.text = "0" + CurrentMinute.ToString("#") + ":" + "0"+ CurrentSecond.ToString("#");
        }
       
    }


    public void StopTimer()
    {
        Stop = true;
    }


}
