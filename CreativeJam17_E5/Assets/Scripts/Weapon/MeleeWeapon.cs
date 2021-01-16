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
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        GameObject attack = Instantiate(meleeAttack, position, Quaternion.identity);

        // Subscribe to the hit event!
        base.ResolveAttack();
    }

    protected void OnAttackHit()
    {
        currentDurability--;
        base.UpdateDurability();
    }
}
