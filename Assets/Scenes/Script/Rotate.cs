using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rotate : MonoBehaviour
{
    private Rigidbody2D rb;
    public Camera cam;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dif =  cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        dif.Normalize();

        float angle = Mathf.Atan2(dif.x, dif.y) * Mathf.Rad2Deg;

        rb.rotation = -angle;
    }
}
