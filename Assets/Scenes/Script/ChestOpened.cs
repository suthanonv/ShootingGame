using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpened : MonoBehaviour
{
    Animator anim;
    bool open = false, empty = false;
    Transform Player;
    [SerializeField] float Range;

    public ChestItem item;

    [SerializeField] private Transform point;

    [SerializeField] ItemList itemlist;
    [SerializeField] OverAllStat stat;
    float CurrentPlus;
    private void Start()
    {
        anim = this.GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player").transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (!open)
            {
                Destroy(collision.gameObject);
                open = true;
                anim.SetBool("IsOpen", true);
            }
        }
    }


    private void Update()
    {

        if (Vector2.Distance(Player.transform.position, this.transform.position) <= Range)
        {

            if (open && !empty)
            {
                empty = true;
            ChestItem i = Instantiate(item, point.transform.position,Quaternion.identity);
                i.Moveing = true;
                i.SetItem(RanItem());
                RemoveChest();
                anim.SetBool("isEmpty", true);
            }
        }
    }


    Item RanItem()
    {
        return itemlist.AlibleItem[Random.Range(0, itemlist.AlibleItem.Count)];
    }

    public void OnStatusChange()
    {
        if (stat.PickUpRange != CurrentPlus)
    
        {
            stat.PickUpRange = CurrentPlus;
            Range += Range * stat.PickUpRange;

        }   
    }

    Vector3 CurrentPoint;
    public void SetChestVector3(Vector3 Point)
    {
        CurrentPoint = Point;
    }
   
    void RemoveChest()
    {
        PlanetSpawning.instance.RemoveChest(CurrentPoint);
    }

}
