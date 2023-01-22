using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUpgrade : MonoBehaviour
{
    public UpgradeItem itemPreFab;
    public Transform Content;
    public UpgradeList uplist;
    void Start()
    {
        SpawnList();
    }

     public void SpawnList()
    {
        foreach(Upgrade i in uplist.AllUpgrade)
        {
            UpgradeItem item = Instantiate(itemPreFab, Content.transform);
            item.SetImage(i);
        }

    }
}
