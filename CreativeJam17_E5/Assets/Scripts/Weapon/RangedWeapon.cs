using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private GameObject projectile;

    protected override void Attack(float modifier)
    {
        // If we're here, the attack prerequisites have already been checked.
        currentDurability--;

        // Spawn projectile! It'll do the rest itself.
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2.0f);
        GameObject proj = Instantiate(projectile, position, transform.rotation);
        proj.GetComponent<ProjectileBehavior>().Damage = weaponData.AttackDamage * modifier;

        base.ResolveAttack();
    }
}
