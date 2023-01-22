using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointManage : MonoBehaviour
{
    public static PointManage instance;

    int CurrentPoint;
    int BoughtPoint;

    public GameObject UpgradePanel;
    public GameObject fream;
    public Score score;
    public Slider meter;
    public Text lv;
    public GameObject slide;
    public int EnemyDeathCount;
    private void Awake()
    {
        instance = this;
    }
    

    public void GetPoint(int Point)
    {
        CurrentPoint += Point;
        score.Scores = CurrentPoint;
        BoughtPoint += Point;
        EnemyDeathCount++;
    }


    int ShowPoint()
    {
        return CurrentPoint;
    }


    private void Update()
    {
        if(SetWeapon.instace.GetWeapon().NextWeapon.Length > 0)
        {
            slide.SetActive(true);
              
            NextWeaponMeter(BoughtPoint, SetWeapon.instace.GetWeapon().NextWeapon[0].PointCost);
            

            if (Check())
            {
                OpenPanel();
            }
           
        }
        else
        {
            slide.SetActive(false);
        }
    }
    

    bool Check()
    {
        if (SetWeapon.instace.GetWeapon().NextWeapon != null)
        {
            foreach(Weapon i in SetWeapon.instace.GetWeapon().NextWeapon)
            {
                if(BoughtPoint >= i.PointCost)
                {
                    BoughtPoint -= i.PointCost;
                    return true;
                }
            }
            return false;
        }
        return false;
    }


    void OpenPanel()
    {
        UpgradePanel.SetActive(true);
        Transform content = UpgradePanel.GetComponent<Transform>();
        CursorLock.instance.MouseLockCheck(false);

        foreach (Weapon i in SetWeapon.instace.GetWeapon().NextWeapon)
        {
            GameObject upgrade = Instantiate(fream, content.transform);
            upgrade.GetComponent<UpgradeFream>().GetWeapon(i);

            var itemname = upgrade.transform.Find("Name").GetComponent<Text>();
            var itemImage = upgrade.GetComponent<Image>();
            itemname.text = i.name.ToString();
            itemImage.sprite = i.Icon;
        }

        Time.timeScale = 0;
    }

    public void ClosePanal()
    {
        UpgradePanel.SetActive(false);
        Transform content = UpgradePanel.GetComponent<Transform>();
        CursorLock.instance.MouseLockCheck(true);

        foreach (Transform i in content)
        {
            Destroy(i.gameObject);
        }

        Time.timeScale = 1;
    }

    void NextWeaponMeter(int point,int MaxPoint)
    {
        if(point > MaxPoint)
        {
            point = MaxPoint;
        }


        lv.text = point.ToString() + "/" + MaxPoint.ToString();
        meter.maxValue = MaxPoint;
        
        
        meter.value = point;
        
    }
}
