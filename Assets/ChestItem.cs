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
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player").transform;
    }


    private void Update()
    {
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
        rb.MovePosition((Vector2)transform.position + (dir * CurrnetSpeed * Time.deltaTime));
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
