using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPoint : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 Point;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dif = Point - transform.position;

        dif.Normalize();

        float angle = Mathf.Atan2(dif.x, dif.y) * Mathf.Rad2Deg;

        rb.rotation = -angle;
    }

    public void SetPoint(Vector3 Point)
    {
        this.Point = Point;
    }

}
