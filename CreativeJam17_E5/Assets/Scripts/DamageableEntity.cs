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
        isAlive = true;
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
                Debug.Log("Death of: " + gameObject.name);
                Die();
            }
        }
    }

    public bool IsAlive()
    {
        return isAlive;
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
        Debug.Log("onRevive");
        isAlive = true;
        currentHealth = maxHealth;

        // Broadcast the revive event
        if (OnRevive != null)
        {
            OnRevive.Invoke();
            Debug.Log("Revive");
        }
    }

    private void Die()
    {
        // Prepare character for death
        isAlive = false;
        // Broadcast the death event
        if(OnDeath != null)
        {
            OnDeath.Invoke();
        }
    }
}
