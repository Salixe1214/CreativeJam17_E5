using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;
    private bool isAlive;

    public Action OnDeath;
    public Action OnRevive;
       
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Don't take damage if dead
        if (isAlive)
        {
            // Take damage
            currentHealth = Math.Max(0, (currentHealth - damage));

            // If life drops to or under 0, die
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetMaxHealth(float newMax, bool shouldHeal = true)
    {
        maxHealth = newMax;
        currentHealth = maxHealth;
    }

    public void Revive()
    {
        // Prepare character for revive
        isAlive = true;
        currentHealth = maxHealth;

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
