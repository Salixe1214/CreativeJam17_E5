using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    [SerializeField] private float MaxHealth;

    private float currentHealth;
    private bool isAlive;

    public Action OnDeath;
    public Action OnRevive;
       
    private void Awake()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Take damage
        currentHealth = Math.Max(0, (currentHealth - damage));

        // If life drops to or under 0, die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Revive()
    {
        // Prepare character for revive
        isAlive = true;
        currentHealth = MaxHealth;

        // Broadcast the revive event
        OnRevive.Invoke();
    }

    private void Die()
    {
        // Prepare character for death
        isAlive = false;

        // Broadcast the death event
        OnDeath.Invoke();
    }
}
