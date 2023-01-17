using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeDesManage : MonoBehaviour
{
    public static UpgradeDesManage instace;

    public GameObject ShowPanel;
    public GameObject UpgradeButton;
    public Text UpgradeName;
    public Image UpgradeImage;
    public Text UpgradeDes;
    public Text UpgradeCost;
    public Text LvText;

    [SerializeField] private int MaxLv;

    Upgrade CurrentUpgrade;

    public Money money;

    private void Awake()
    {
        instace = this;
    }

    public void SetDesCription(Upgrade newUpgrade)
    {
        ShowPanel.SetActive(true);
        CurrentUpgrade = newUpgrade;
        UpgradeName.text = CurrentUpgrade.Name; // Set Upgrade Name
        UpgradeDes.text = CurrentUpgrade.Des; // Set Des Detail
        UpgradeImage.sprite = CurrentUpgrade.UpgradeSprite; // Set Icon

        LvText.text = "Lv " + CurrentUpgrade.CurrentLV.ToString() + "/" + MaxLv.ToString();
        Check();
    }

    void Check()
    {
        if(CurrentUpgrade.CurrentLV > MaxLv)
        {
            UpgradeButton.SetActive(false);
        }
        else
        {
            UpgradeCost.text = CurrentUpgrade.Cost[CurrentUpgrade.CurrentLV].ToString();
        }
    }

    public void Upgrade()
    {
        if(money.CurrentMoney >= CurrentUpgrade.Cost[CurrentUpgrade.CurrentLV])
        {
            money.CurrentMoney -= CurrentUpgrade.Cost[CurrentUpgrade.CurrentLV];
            CurrentUpgrade.CurrentLV += 1;
            SetMoney.instace.SetCurrentMoney();
        }
    }

}
