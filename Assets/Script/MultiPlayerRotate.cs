using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MultiPlayerRotate : MonoBehaviour
{
    private Rigidbody2D rb;
    PhotonView view;
    public Camera cam;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        view = this.GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            Vector3 dif = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            dif.Normalize();

            float angle = Mathf.Atan2(dif.x, dif.y) * Mathf.Rad2Deg;

            rb.rotation = -angle;
        }
    }
}
