using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnDeath : MonoBehaviour
{
    private DamageableEntity damageable;
    private GameObject toDisable;

    private void Awake()
    {
        toDisable = gameObject;
        damageable = GetComponentInChildren<DamageableEntity>();

        damageable.OnDeath += Die;
    }

    private void Die()
    {
        toDisable.SetActive(false);
    }
}
