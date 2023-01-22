using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MultiPlayerHealth : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    float CurrentHealth;

    public UnityEvent Died;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage()
    {
        CurrentHealth -= 1;

        if(CurrentHealth <= 0)
        {
            Died.Invoke();
        }
    }
}
