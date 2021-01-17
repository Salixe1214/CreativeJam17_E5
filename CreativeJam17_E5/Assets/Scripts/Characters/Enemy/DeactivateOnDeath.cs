using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnDeath : MonoBehaviour
{
    [SerializeField] private DamageableEntity damageable;
    [SerializeField] private GameObject toDisable;
    [SerializeField] private GameObject deathVfx;

    private void Awake()
    {
        if (!toDisable) toDisable = gameObject;
        if (!damageable) damageable = GetComponentInChildren<DamageableEntity>();

        damageable.OnDeath += Die;
    }

    private void Die()
    {
        toDisable.SetActive(false);
        if (deathVfx)
        {
            Instantiate(deathVfx, new Vector3(transform.position.x, transform.position.y, 0.9f), Quaternion.identity);
        }
    }
}
