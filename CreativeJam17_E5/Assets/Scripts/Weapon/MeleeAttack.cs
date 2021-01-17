using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float lifetimeSeconds;
    [SerializeField] private float knockbackForce = 12000.0f;
    [NonSerialized] public float Damage;

    private GameObject followObject;
    private Vector2 offset;

    private float deathTime;
    public Action OnAttackHit;

    static public Action<GameObject> onHit;

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
            transform.position = new Vector3(transform.position.x, transform.position.y, -2.0f);
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
            if (onHit != null)
            {
                onHit.Invoke(collision.gameObject);
            }
            // Deal your damage
            // Possibility of a persistent projectile / hit-point system?

            if (OnAttackHit != null) OnAttackHit.Invoke();
            damageable.TakeDamage(Damage);
        }

        // Is it a ghost?
        Transform parent = collision.gameObject.transform.parent;
        if (parent != null)
        {
            GhostMovement ghost = parent.GetComponentInChildren<GhostMovement>();
            if (ghost != null)
            {
                ghost.Knockback(transform.up * knockbackForce);
            }
        }

    }
}
