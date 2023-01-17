using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Photon.Pun;
public class MultiWalk : MonoBehaviour
{
    [SerializeField] float Speed;
    Rigidbody2D rb;
    Vector2 Movement;

    PhotonView view;
    public GameObject[] Cam;

    private void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        view = this.GetComponent<PhotonView>();

        if (!view.IsMine)
        {
            foreach (GameObject i in Cam)
            {
                Destroy(i.gameObject);
            }
        }
    
    }

    private void Update()
    {
        if (view.IsMine)
        {
            Movement.x = Input.GetAxis("Horizontal");
            Movement.y = Input.GetAxis("Vertical");
        }
        
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            rb.MovePosition(rb.position + Movement * Speed * Time.fixedDeltaTime);
            
        }
         
     
    }
}
