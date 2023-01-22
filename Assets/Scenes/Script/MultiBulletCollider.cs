using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBulletCollider : MonoBehaviour
{
    [SerializeField] private float destroyTime = 5f;
    [SerializeField] private float damage = 20;
    [SerializeField] private float Priceing = 1;
    float pricingCount = 0;
    public GameObject BulletEffect;

    Transform player;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<MultiEnemyHealth>().TakeDamage(damage);
            collision.GetComponent<MultiEnemyWalk>().SetPlayerTransform(player);
            GameObject effect = Instantiate(BulletEffect, this.transform.position, Quaternion.identity);
            Destroy(effect, 0.35f);
            pricingCount++;

            if (pricingCount >= Priceing)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            pricingCount += 0.5f;

            if (pricingCount >= Priceing)
            {
                GameObject effect = Instantiate(BulletEffect, this.transform.position, Quaternion.identity);
                Destroy(effect, 0.35f);
                Destroy(gameObject);
            }

        }

    }

    public void SetTransfrom(Transform ShootPlayer)
    {
        player = ShootPlayer;
    }
}
