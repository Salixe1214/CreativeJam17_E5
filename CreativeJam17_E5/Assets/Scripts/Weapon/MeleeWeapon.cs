using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private GameObject meleeAttack;

    protected override void Attack()
    {
        // Spawn attack! It'll do the rest itself.
        // TODO: projectile rotation!
        GameObject attack = Instantiate(meleeAttack, this.transform.position, Quaternion.identity);

        // Subscribe to the hit event!
        base.ResolveAttack();
    }

    protected void OnAttackHit()
    {
        currentDurability--;
        base.UpdateDurability();
    }
}
