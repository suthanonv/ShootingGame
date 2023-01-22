using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiEnemyRotate : MonoBehaviour
{
    Transform Player;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dif = Player.transform.position - transform.position;
        dif.Normalize();
        float Angle = Mathf.Atan2(dif.x, dif.y) * Mathf.Rad2Deg;

        rb.rotation = -Angle;

    }

    public void SetEnemyRotate(Transform newPlayer)
    {
        Player = newPlayer;
    }
}
