using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    // Current weapon!
    private Weapon currentWeapon;
    
    // Hands are a melee weapon, after all.
    private MeleeWeapon handsWeapon;

    public Action OnWeaponEquipped;

    public void EquipWeapon(Weapon newWeapon)
    {
        // Can only equip a weapon if it doesn't have one
        if (!currentWeapon)
        {
            currentWeapon = newWeapon;
            currentWeapon.OnWeaponBroken += WeaponBroken;

            OnWeaponEquipped.Invoke();
        }
    }

    private void WeaponBroken()
    {
        currentWeapon.OnWeaponBroken -= WeaponBroken;
        currentWeapon = null;
    }

    public void Attack()
    {
        if (currentWeapon)
        {
            currentWeapon.AttemptAttack();
        }
        else
        {
            // Attack with your hands!
            handsWeapon.AttemptAttack();
        }
    }
}
