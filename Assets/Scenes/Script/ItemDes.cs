using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDes : MonoBehaviour
{
    Item CurrentItem;
    [SerializeField] Text Name;
    [SerializeField] Transform DesContent;
    [SerializeField] public Text DesPreFab;
    public void SetUI(Item thisitem)
    {
        CurrentItem = thisitem;
        Name.text = CurrentItem.Name;

    foreach(var i in CurrentItem.Description)
        {
            Text desPrefab = Instantiate(DesPreFab, DesContent.transform);
            desPrefab.text = i;
        }
    }

    public void Forgive()
    {
        itemDesManager.instance.RejectItem();
        Destroy(this.gameObject);
    }

    public void Accept()
    {
        itemDesManager.instance.UseItem(CurrentItem);
        Destroy(this.gameObject);
    }


}
