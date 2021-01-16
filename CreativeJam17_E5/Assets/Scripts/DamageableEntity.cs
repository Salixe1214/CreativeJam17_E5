using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    [SerializeField] private float MaxHealth;

    private float currentHealth;
    private float currentResistance;
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
        float totalDamage = damage * currentResistance;
        currentHealth = Math.Max(0, (currentHealth - totalDamage));

        // If life drops to or under 0, die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeTrueDamage(float damage)
    {
        // Take Damage
        currentHealth = Math.Max(0, (currentHealth - damage));

        // If life drops to or under 0, die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void SetResistance(float resistance)
    {
        currentResistance = resistance;
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
