using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestItem : MonoBehaviour
{
    Transform Player;
    Rigidbody2D rb;

    Vector2 movement;
    Item itemdrop;
    public float CurrnetSpeed = 5;
    public bool Moveing;

    public float Range = 5;
    [SerializeField] OverAllStat stat;
    public Shooting x;

    void Start()
    {
        Range += Range * stat.PickUpRange;
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player").transform;


    }


    private void Update()
    {
if(Vector2.Distance(this.transform.position,Player.transform.position) <= Range)
        {
            Moveing = true;
        }


     Vector3  dir = Player.position - transform.position;
        dir.Normalize();

        movement = dir;
    }
  

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    private void MoveCharacter(Vector2 dir)
    {
        if (Moveing)
        {
            rb.MovePosition((Vector2)transform.position + (dir * CurrnetSpeed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            itemDesManager.instance.GetNewItem(itemdrop);
            Destroy(gameObject);
        }
    }

    public void SetItem(Item newitem)
    {
        itemdrop = newitem;
    }
}
