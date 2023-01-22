using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    float CurrentHealth;
    [SerializeField] private int Point = 50;

    public GameObject DeathEffect;

    private void Start()
    {
        CurrentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        playSound.instance.PlayenemyGothit();
        if(CurrentHealth <=0)
        {
       GameObject effect = Instantiate(DeathEffect, this.transform.position, Quaternion.identity);
            PointManage.instance.GetPoint(Point);
            Destroy(effect, .5f);
            Destroy(gameObject);
        }

    }
}
