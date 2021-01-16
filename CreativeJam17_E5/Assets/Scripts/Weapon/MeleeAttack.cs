using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float lifetimeSeconds;
    private float damage;
    private float deathTime;

    public Action OnAttackHit;

    private void Awake()
    {
        deathTime = Time.time + lifetimeSeconds;
    }

    private void Update()
    {
        // If its lifetime expired
        if (Time.time >= deathTime)
        {
            // Destroy itself
            Destroy(this);
        }
    }

    public void OnCollisionEnter2D(Collision collision)
    {
        // Is it damageable?
        DamageableEntity damageable = collision.gameObject.GetComponent<DamageableEntity>();
        if (damageable)
        {
            // Tag system to prevent team damage!
            if (damageable.tag != this.tag)
            {
                // Deal your damage
                // Possibility of a persistent projectile / hit-point system?
                damageable.TakeDamage(damage);
                OnAttackHit.Invoke();
            }
        }
    }
}
