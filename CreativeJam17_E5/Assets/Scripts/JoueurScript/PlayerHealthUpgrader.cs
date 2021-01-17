using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUpgrader : MonoBehaviour
{
    [SerializeField] private statisticsGestion stats;

    private DamageableEntity damageable;

    private void Awake()
    {
        damageable = GetComponent<DamageableEntity>();
        stats.onResistUp += UpgradeHealth;
    }

    private void UpgradeHealth(int obj)
    {
        damageable.SetMaxHealth(damageable.GetMaxHealth() + obj);
    }
}
