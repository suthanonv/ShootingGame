using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    
    public GameObject BulletEffect;

    [SerializeField] private float Pricing = 0;
   
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamge();
            GameObject effect = Instantiate(BulletEffect, this.transform.position, Quaternion.identity);
            Destroy(effect, 0.35f);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            Pricing--;

            if (Pricing <= 0)
            {
                GameObject effect = Instantiate(BulletEffect, this.transform.position, Quaternion.identity);
                Destroy(effect, 0.35f);
                Destroy(gameObject);
            }
        }
    }
}
