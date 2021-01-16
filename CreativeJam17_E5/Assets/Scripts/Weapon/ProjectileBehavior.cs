using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float lifetimeSeconds;
    [NonSerialized] public float Damage;

    private Rigidbody2D rigidBody;


    private float deathTime;

    private void Awake()
    {
        deathTime = Time.time + lifetimeSeconds;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move the object "forwards"
        Vector3 deltaPos = transform.up * movementSpeed * Time.deltaTime;
        rigidBody.MovePosition(transform.position += deltaPos);

        // If its lifetime expired
        if (Time.time >= deathTime)
        {
            // Destroy itself
            Destroy(gameObject);
        }
    }

    // We collided with something!
    private void OnTriggerEnter2D(Collider2D collision)
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
                damageable.TakeDamage(Damage);

                // Destroy itself
                Destroy(gameObject);
            }
        }
    }
}
