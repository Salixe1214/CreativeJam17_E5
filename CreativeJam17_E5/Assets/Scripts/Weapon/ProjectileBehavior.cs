using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float lifetimeSeconds;
    private Rigidbody rigidBody;

    private float damage;
    private float deathTime;

    private void Awake()
    {
        deathTime = Time.time + lifetimeSeconds;
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Move the object "forwards"
        Vector3 deltaPos = Vector3.right * movementSpeed * Time.deltaTime;
        rigidBody.MovePosition(transform.position += deltaPos);

        // If its lifetime expired
        if (Time.time >= deathTime)
        {
            // Destroy itself
            Destroy(this);
        }
    }

    // We collided with something!
    private void OnCollisionEnter2D(Collision collision)
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

                // Destroy itself
                Destroy(this);
            }
        }
    }
}
