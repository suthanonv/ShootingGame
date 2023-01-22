using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeItem : MonoBehaviour
{
    public Image UpgradeImage;
    Upgrade CurrentUp;
    public void SetImage(Upgrade newUpgrade)
    {
        CurrentUp = newUpgrade;
        UpgradeImage.sprite = CurrentUp.UpgradeSprite;
    }

    public void OnClick()
    {
        UpgradeDesManage.instace.SetDesCription(CurrentUp);
    }
       
}
