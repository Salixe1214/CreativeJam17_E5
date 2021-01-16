﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingeringAttack : MonoBehaviour
{
    [SerializeField] public float Damage;
    [SerializeField] public float HitboxRefreshSeconds;

    private Collider2D attackCollider;

    private void Awake()
    {
        attackCollider = GetComponent<Collider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Is it damageable?
        DamageableEntity damageable = collision.gameObject.GetComponentInChildren<DamageableEntity>();
        if (damageable)
        {
            // Deal your damage
            damageable.TakeDamage(Damage);

            // Have a refresh system so you can take damage many times if he's over you all the time
            StartCoroutine(RefreshHitbox());
        }
    }

    public IEnumerator RefreshHitbox()
    {
        float endTime = Time.time + HitboxRefreshSeconds;
        attackCollider.enabled = false;

        while (endTime > Time.time)
        {
            yield return new WaitForEndOfFrame();
        }

        attackCollider.enabled = true;
        yield return null;
    }
}