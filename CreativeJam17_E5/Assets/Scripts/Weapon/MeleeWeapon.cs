using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private GameObject meleeAttack;

    protected override void Attack()
    {
        // Spawn attack! It'll do the rest itself.
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        GameObject attack = Instantiate(meleeAttack, position, Quaternion.identity);

        attack.GetComponent<MeleeAttack>().FollowObject(gameObject, attackOffset);

        // Subscribe to the hit event!
        base.ResolveAttack();
    }

    protected void OnAttackHit()
    {
        currentDurability--;
        base.UpdateDurability();
    }
}
