using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private GameObject projectile;

    protected override void Attack()
    {
        // If we're here, the attack prerequisites have already been checked.
        currentDurability--;

        // Spawn projectile! It'll do the rest itself.
        // TODO: projectile rotation!
        Instantiate(projectile, this.transform.position, Quaternion.identity);

        base.ResolveAttack();
    }
}
