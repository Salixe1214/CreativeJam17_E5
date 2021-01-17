using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // The data of the weapon.
    [SerializeField] protected Vector2 attackOffset;

    public WeaponData weaponData;

    // The durability left on the weapon.
    protected int currentDurability;

    // To prevent spamming attacks
    protected float lastAttack;

    public Action OnWeaponBroken;
    public Action OnDurabilityUpdated;

    protected void Awake()
    {
        currentDurability = weaponData.Durability;
    }

    // Try an attack. Accounts for cooldown.
    public void AttemptAttack(float modifier)
    {
        float allowedAttackTime = lastAttack + weaponData.CooldownSeconds;
        if (allowedAttackTime <= Time.time)
        {
            Attack(modifier);
        }
    }

    // To implement by children weapons. Else it'll just do this.
    // Attack. Protected so you can't externally force an attack.
    protected virtual void Attack(float modifier)
    {
        ResolveAttack();
    }

    // After an attack is done, call this. Universal to all weapons.
    protected void ResolveAttack()
    {
        // Attack action here
        lastAttack = Time.time;

        UpdateDurability();
    }

    protected void UpdateDurability()
    {
        if (OnDurabilityUpdated != null) OnDurabilityUpdated();

        // Durability use is handled by children classes
        if (currentDurability <= 0 && weaponData.Breakable)
        {
            BreakWeapon();
        }
    }

    // When the weapon is broken. Update the UI and stuff.
    public void BreakWeapon()
    {
        if(OnWeaponBroken != null) OnWeaponBroken.Invoke();
    }

    public int GetDurability()
    {
        return currentDurability;
    }
}
