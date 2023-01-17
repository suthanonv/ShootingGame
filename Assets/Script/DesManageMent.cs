using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DesManageMent : MonoBehaviour
{
    public static DesManageMent instace;

    public CurrentCharacter CurrentCharacter;
   public GameObject Panel;
    Character CurrentChar;
    [SerializeField] private int MaxShipLv;

    [Header("Ship Detail")]
    public Text Name;
    public Text SkillName;
    public Text SkillDes;
    public Text SkillCd;
    public Image SkillImage;
    public Image ShipImage;
    public Text LvText;

    [Header("Buy")]
    public GameObject BuyButton;
    public Text BuyMode;
    public Text CostText;

    [Header("slier")]
    public Slider Health;
    public Text HealthText;
    [SerializeField] private int MaxHealthStat;
    public Slider Armor;
    public Text ArmorText;
    [SerializeField] private int MaxArmorStat;
    public Slider Speed;
    public Text SpeedText;
    [SerializeField] private int MaxSpeedStat;

    public Money money;

    private void Awake()
    {
        instace = this;
    }


    public void SetDes(Character ChooseCharacter)
    {
        CurrentChar = ChooseCharacter;
        Panel.SetActive(true);
        CurrentCharacter.CharacterUse = ChooseCharacter;
        ShipImage.sprite = ChooseCharacter.Icon;
        SkillImage.sprite = ChooseCharacter.Des.SkillIcon;
        Name.text = ChooseCharacter.CharacterName;
        SkillName.text = ChooseCharacter.Des.SkillName;
        SkillDes.text = ChooseCharacter.Des.SKillDes;
        SkillCd.text = "CD skill: " + ChooseCharacter.Des.SkillCD.ToString();

        Check();
        ShowStaTus();
    }


    void Check()
    {
        LvText.text = "Lv " +CurrentChar.CurrentLv.ToString() +"/" + MaxShipLv.ToString();
        if (!CurrentChar.isUnlock)
        {
            BuyButton.SetActive(true);
            BuyMode.text = "Unlock";
            CostText.text = CurrentChar.ChracterCost.ToString();
        }
        else
        {
            if (CurrentChar.CurrentLv < MaxShipLv)
            {
                BuyButton.SetActive(true);
                BuyMode.text = "Upgrade";
                CostText.text = CurrentChar.UpgradeCost[CurrentChar.CurrentLv].ToString();
            }
            else
            {
                BuyButton.SetActive(false);
            }
        }
    }

    void ShowStaTus()
    {
        Health.maxValue = MaxHealthStat;
        Armor.maxValue = MaxArmorStat;
        Speed.maxValue = MaxSpeedStat;

        Health.value = CurrentChar.Stat.Health[CurrentChar.CurrentLv];
        Armor.value = CurrentChar.Stat.Armor[CurrentChar.CurrentLv];
        Speed.value = CurrentChar.Stat.Speed[CurrentChar.CurrentLv];

        HealthText.text = CurrentChar.Stat.Health[CurrentChar.CurrentLv].ToString();
        ArmorText.text = CurrentChar.Stat.Armor[CurrentChar.CurrentLv].ToString();
        SpeedText.text = CurrentChar.Stat.Speed[CurrentChar.CurrentLv].ToString();
    }


    public void Upgrade()
    {
        if(!CurrentChar.isUnlock)
        {
            if(money.CurrentMoney >= CurrentChar.ChracterCost)
            {
                money.CurrentMoney -= CurrentChar.ChracterCost;
                CurrentChar.isUnlock = true;
                SetDes(CurrentChar);
                SetMoney.instace.SetCurrentMoney();
            }
        }
        else
        {
            if (money.CurrentMoney >= CurrentChar.UpgradeCost[CurrentChar.CurrentLv])
            {
                if(money.CurrentMoney >= CurrentChar.UpgradeCost[CurrentChar.CurrentLv])
                {
                    money.CurrentMoney -= CurrentChar.UpgradeCost[CurrentChar.CurrentLv];
                    CurrentChar.CurrentLv += 1;
                    SetDes(CurrentChar);
                    SetMoney.instace.SetCurrentMoney();
                }
            }
        }
    }
        
}
