using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float lifetimeSeconds;
    [NonSerialized] public float Damage;

    private GameObject followObject;
    private Vector2 offset;

    private float deathTime;
    public Action OnAttackHit;

    private void Awake()
    {
        deathTime = Time.time + lifetimeSeconds;
    }

    private void Update()
    {
        // If its lifetime expired
        if (followObject)
        {
            Vector2 followPos = new Vector2(followObject.transform.position.x, followObject.transform.position.y);
            transform.position = followPos + offset;
        }

        if (Time.time >= deathTime)
        {
            // Destroy itself
            Destroy(gameObject);
        }
    }

    public void FollowObject(GameObject obj, Vector2 followOffset)
    {
        followObject = obj;
        offset = followOffset;

        Vector2 followPos = new Vector2(followObject.transform.position.x, followObject.transform.position.y);
        transform.position = followPos + offset;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Is it damageable?
        DamageableEntity damageable = collision.gameObject.GetComponent<DamageableEntity>();
        if (damageable)
        {
            // Deal your damage
            // Possibility of a persistent projectile / hit-point system?
            Debug.Log("Hit!" + collision.name);
            damageable.TakeDamage(Damage);
        }
    }
}
