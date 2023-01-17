using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetResult : MonoBehaviour
{
    public static SetResult instance;
    [Header("Suvied")]
    public Text SuviedText;
    public Text SuviedGain;
    int SMinute,Ssec;
    int Sgain;

    [Header("Killed")]
    public Text KilledCount;
    public Text KilledGain;
    int Kgain;

    [Header("Money Earned")]
    public Text MoneyEarned;
    int Allgain;
    public Money money;

    [Header("Gmae stat")]
    public Text TypeText;
    [SerializeField] private Color Death;
    [SerializeField] private Color Victory;
    public enum Stat
    {
        Died,
        Suvied
    }

    private void Awake()
    {
        instance = this;
    }

    public void SetKilled()
    {
        Kgain = PointManage.instance.EnemyDeathCount;
        KilledCount.text = "(" + Kgain.ToString() + ")";
        KilledGain.text = Kgain.ToString();
    }

    public void SetTimeer(float Timer)
    {
        SMinute = 0;
        Sgain = (int)Mathf.Round(Timer);
        SuviedGain.text = Sgain.ToString();
        Ssec = Sgain;
        while (Ssec >= 60)
        {
            Ssec -= 60;
           
            SMinute++;
        }
    
        
        if(SMinute > 9 && Ssec > 9)
        {
            SuviedText.text = "(" + SMinute.ToString() + ":" + Ssec.ToString() + ")";
        }
        else if(SMinute <= 9 && Ssec > 9)
        {
            SuviedText.text = "(" + "0"+ SMinute.ToString() + ":" + Ssec.ToString() + ")";
        }
        else if(SMinute > 9 && Ssec <= 9)
        {
            SuviedText.text = "("  + SMinute.ToString() + ":" + "0" + Ssec.ToString() + ")";
        }
        else if(SMinute <= 9 && Ssec <= 9)
        {
            SuviedText.text = "(" + "0" + SMinute.ToString() + ":" + "0" + Ssec.ToString() + ")";
        }

    }

    public void SetEarned()
    {
        SetKilled();
        Allgain = Kgain + Sgain;
        MoneyEarned.text = Allgain.ToString();
        money.CurrentMoney += Allgain;
    }

    public void SetisDeath(bool isDeath)
    {
        if (isDeath)
        {
            TypeText.text = "Your Death";
            TypeText.color = Death;
        }
        else
        {
            TypeText.text = "you survived";
            TypeText.color = Victory;
        }
        }

    }





