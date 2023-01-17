using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetMoney : MonoBehaviour
{
    public static SetMoney instace;
    public Text[] MoneyText;
    public Money Money;

    private void Awake()
    {
        instace = this; 
    }
    void Start()
    {
        SetCurrentMoney();
    }

    public void SetCurrentMoney()
    {
        foreach(Text i in MoneyText)
        {
            i.text = Money.CurrentMoney.ToString();
        }
    }
}
